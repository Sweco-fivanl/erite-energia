using System;
using System.Diagnostics;

namespace EriteLib
{


    public class EriteLaskuri
    {

        private TaloAttributes _attrs;

        public EriteLaskuri()
        {
            _attrs = new TaloAttributes
            {
                Area = 147.0, // m2
                InTemp = 21.0, // C
                Ventilation = new Ventilation
                {
                    RunningHours = 24,
                    Ulkoilmavirta = 0.4, // dm/s,m2
                    LTO_COP = 0.50, // vuosihyötysuhde
                    KorvausilmanLampo = 18.0, // tulo huoneeseen, astetta-C

                }
            };
        }

        //private double _tuloilmavirta;

        private const double OutdoorTempJanuary = -3.97; // tampere

        //private const int HoursInMonth
        public int LaskeJotain()
        {
            return 0;
        }


        // TODO: kuukausi
        public double MaanvaraisenLaatanJohtumishavio()
        {
            var Tu_vuosi = 5.57;
            var dTmaa_vuosi = 5.0;
            var vuotuinen_keskilampo = Tu_vuosi + dTmaa_vuosi;
            Debug.WriteLine($"[ERITE] vuotuinen keskilampo: {vuotuinen_keskilampo}");

            var Tmaa_tammikuu = vuotuinen_keskilampo + 0;
            var Uarvo = 0.24;
            // TODO: rossipohjalle U-kerroin 0.9

            var pAla = _attrs.Area;
            var sisalampo = _attrs.InTemp;
            var Q = (Uarvo * pAla * (sisalampo - Tmaa_tammikuu) * HoursInMonth(1) ) /1000;


            return Q;
        }

        // 11§ Rakennuksen vakioitu kaytto
        // 10 § Ulkoilmavirrat ja huonelampotilat
        public double IlmanvaihdonLammitysenergia()
        {
            // "vain korostukset" kaava 3.11

            return 0;
        }

        private const double IlmanTiheys = 1.2; // kg/m3
        private const double IlmanOmLampKap = 1000; // J/kg*K

        public double VuotoilmanLammitysenergia()
        {
            var n50 = 4.0; // TODO: taulukosta, 1/h, per vuosikymmen
            var ikkunaAla = 24.4;
            var vaipanAlaJaAlapohja = 2 * 140.0 + 90.0 + ikkunaAla + 8.2;
            Debug.WriteLine($"[ERITE] vaipan ja alapohjan pinta-ala: {vaipanAlaJaAlapohja} m2");

            var kohteenIlmatilavuus = 382;

            var q50 = GetQ50(n50, vaipanAlaJaAlapohja, kohteenIlmatilavuus);

            var qv_vuotoilma = (q50 * vaipanAlaJaAlapohja) / (3600 * 35); //< todo: wtf is 35?
            Debug.WriteLine($"[ERITE] qv, vuotoilma: {qv_vuotoilma} m3/s");

            var att_Ts = _attrs.InTemp;
            var att_Tu = OutdoorTempJanuary;


            var Q_vuotoilma = (IlmanTiheys * IlmanOmLampKap * qv_vuotoilma * (att_Ts - att_Tu) * HoursInMonth(1)) / 1000;

            return Q_vuotoilma;
        }

        private double GetPoistoIlmaVirta()
        {
            return _attrs.Area * _attrs.Ventilation.Ulkoilmavirta / 1000; // dm3 -> m3
        }

        // kerroin sähkö ??
        internal double IVNettotarvePartial()
        {
            // TODO: lähtöarvo, tulo-poisto tasapaino
            // todo: kuukausittaiset keskilämpötilat, per asuinpaikka
            // jotain se höpötti painovoimainen vs. koneellinen
            // TODO: lähtöarvo, LTO:n vuosihyötysuhde


            var poistoilmavirta = GetPoistoIlmaVirta();
            // TODO: kerro 24/7 arvolla
            Debug.WriteLine($"[ERITE] poistoilmavirta: {poistoilmavirta} m3/s");
            var T_sisa = _attrs.InTemp;
            var T_ulko = OutdoorTempJanuary;
            // TODO: 30 % taulukkoarvo, riippuu vuosiluvusta
            //       voi olla myös painovoimainen, nolla
            var scop = _attrs.Ventilation.LTO_COP ?? 0.30;
            Debug.WriteLine($"[ERITE] LTO vuosihyotysuhde: {scop * 100} %.");

            var runFact = _attrs.Ventilation.RunningHours / 24;
            // lämmöntalteenotolla talteenotettu teho (tammikuu) kaava 3.12
            var theta = scop * runFact * IlmanTiheys * IlmanOmLampKap * poistoilmavirta * (T_sisa - T_ulko);
            Debug.WriteLine($"[ERITE] LTO talteenotettu teho: {theta} W.");

            // lämmöntalteenoton jälkeinen tuloilman keskimääräinen lämpötila (tammikuu)
            // Kaava 3.11
            var tuloilmavirta = poistoilmavirta;
            var weeFact = 1.0;
            var T_lto = T_ulko + (theta / (runFact * weeFact * IlmanTiheys * IlmanOmLampKap * tuloilmavirta));
            Debug.WriteLine($"[ERITE] LTO temp: {T_lto} C.");

            // Kaava 3.10
            var T_sp = _attrs.Ventilation.KorvausilmanLampo; // sisään puhallettava ilma e.g. 18'C
            var dT_puh = 0;//T_sisa - T_sp;
            var Q_iv = runFact * weeFact * IlmanTiheys * IlmanOmLampKap * tuloilmavirta*((T_sp - dT_puh) - T_lto) *
                       HoursInMonth(1) / 1000;
            Debug.WriteLine($"[ERITE] Ilmanvaihdon lamm. nettotarve: {Q_iv} kWh.");

            // Kaava 3.14
            // 18C - 21C (öljylämmityksen kertoimella)

            // Q_iv (sähkön kertoimella)

            return Q_iv;
        }

        public double IVBrutto()
        {
            // piti tulla 148
            var kaikki = IVTuloilmanLammittaminen();
            var lto = IVNettotarvePartial();
            return kaikki - lto;
        }

        
        // kerroin öljy
        internal double IVTuloilmanLammittaminen()
        {
            var T_sisa = _attrs.InTemp;
            //var T_sisaan = _attrs.Ventilation.KorvausilmanLampo;
            var T_ulko = OutdoorTempJanuary;
            //var dT_vent = T_sisa - T_sisaan;
            var tuloilmavirta = GetPoistoIlmaVirta();

            var Q_iv_korv = IlmanTiheys * IlmanOmLampKap * tuloilmavirta * (T_sisa - T_ulko) *
                       HoursInMonth(1) / 1000;
            Debug.WriteLine($"[ERITE] Korvausilman lämpenemisen lämpöenergian tarve: {Q_iv_korv} kWh.");
            return Q_iv_korv;
        }

        private const int Hattu = 35; // kWh/m2-v
        private const int ThresholdHattu = 4200; // kWh

        internal double KayttoVedenVakioituKaytto()
        {
            var ala = _attrs.Area;
            // lämpimän käyttöveden tarve vuodessa

            var tarve = ala * Hattu;
            var tarveValittu = Math.Min(tarve, ThresholdHattu);
            Debug.WriteLine($"[ERITE] Käyttöveden lämmitysenergian tarve: {tarveValittu} kWh.");


            return tarveValittu;



        }

        public double LKVTarve()
        {
            // TODO: kaava 6.5
            // laske energia...
            // TAulukko 6.4
            // siirron vuosihyötysuhde
            var taulukosta = 0.96;
            var kiertoHavio = LKVKierto();
            var varaajaHavio = 0;
            var kuukausi = (KayttoVedenVakioituKaytto()/ taulukosta) * (DaysInMonth(1)/365.0) + varaajaHavio + kiertoHavio;
            Debug.WriteLine($"[ERITE] LKV energia: {kuukausi} kWh.");
            return kuukausi;
        }

        internal double LKVKierto()
        {
            var ala = _attrs.Area;

            // Kiertojohdon pituus taulukosta 6.7
            var Llkv_omin = 0.2; // Kiertojohdon ominaispituus: Llkv, omin, m / m2
            // kiertojohdon eristys (taulukko 6.6)
            var Llkv_havio = 15; // kv, kiertohäviö, omin, W / m
            // TODO: varaajahäviöt pitäs laskee tähän
            // KOULU case, öljykattilan kanssa ei erillistä varaajaa, häviöt lasketaan erikseen.

            // kiertojohdon häviön teho
            var havioTeho = ala * Llkv_omin * Llkv_havio;
            //Debug.WriteLine($"[ERITE] LKV kierto häviö: {havioTeho} W.");

            // kiertojohdon häviö tammikuussa
            var kwht = havioTeho * HoursInMonth(1) / 1000;
            Debug.WriteLine($"[ERITE] LKV kierto häviö: {havioTeho} W, {kwht} kWh.");
            return kwht;
        }

        // m3/h*m2
        private double GetQ50(double n50, double alaVaippaKaikki, int ilmatilavuus)
        {
            var ret = (n50/alaVaippaKaikki)*ilmatilavuus;
            Debug.WriteLine($"[ERITE] Q50: {ret} m3/h*m2");
            return ret;
        }

        private int HoursInMonth(int month)
        {
            return 24 * DaysInMonth(month);
        }

        private int DaysInMonth(int month)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                {
                    return 31;
                }
                case 4:
                {
                    return 28;
                }
                default:
                {
                    return 30;
                }
            }
        }

    }
}
