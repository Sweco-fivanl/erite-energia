using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Linq.Enumerable;
//using System.IO.FileSystem;

namespace EriteLib
{


    public class EriteLaskuri
    {

        private TaloAttributes _attrs;
        private Dictionary<Constants.KK, double> _Qvuotoilmat;
        //private Dictionary<Constants.KK, double> _Q_iv_korvausilma_vuodelle; // lammitys kWh
        private Dictionary<Constants.KK, double> _OutdoorTemp;

        // ILP SPF-luku
        private const double ILP_COP = 2.8;
        // TODO: VILP taulukko 12. "Energiatodistusasetus 2018 liitteineen.pdf"

        public EriteLaskuri()
        {

            _Qvuotoilmat = new Dictionary<Constants.KK, double>(12);

            // TODO: get by paikkakunta
            _OutdoorTemp = Constants.Tu_Vyohyke_I.ToDictionary(t => t.Key, t => t.Value);

            Debug.WriteLine($"[ERITE] _________uusi laskelma___________");
        }

        public void SetConfig(TaloAttributes attributes)
        {
            _attrs = attributes;
            /*
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
            */
        }

        //private double _tuloilmavirta;



        //private const int HoursInMonth
        public int LaskeELuku()
        {
            // laske nama taustalle
            if (0 == _Qvuotoilmat.Count) VuotoilmanLammitysenergiaPerVuosi();

            var eKulutus = 0d;
            foreach (int kuukausi in Range(1, 12))
            {
                eKulutus += Kohta9LammitysjarjestelmanEnergiankulutus(kuukausi);
            }
            
            Debug.WriteLine($"[ERITE] Kokonaisenergiankulutus yhteensa: {string.Format("{0:0.00}", eKulutus)} kWh_E)");
            int eLuku = Convert.ToInt32(eKulutus / _attrs.NetArea);
            return eLuku;
        }


        // TODO: kuukausi
        public double MaanvaraisenLaatanJohtumishavio(int kk)
        {
            var kuukausi = kk.Kuukausi();
            var Tu_vuosi = 5.57;
            var dTmaa_vuosi = 5.0;
            var vuotuinen_keskilampo = Tu_vuosi + dTmaa_vuosi;
            Debug.WriteLine($"[ERITE] vuotuinen keskilampo: {vuotuinen_keskilampo}");

            //Dictionary<int, double> Quut = new Dictionary<int, double>(12);
            //foreach (var index in Range(1, 1 /*2*/))
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                //var Tmaa_tammikuu = vuotuinen_keskilampo + 0;
                var Tmaa_kuukausi = vuotuinen_keskilampo + Constants.dT_maa[kuukausi];

                var Q = 0d;
                foreach (var alaPohja in _attrs.Alapohjat)
                {
                    var Uarvo = alaPohja.UArvo;
                    // TODO: rossipohjalle U-kerroin 0.9

                    var pAla = alaPohja.Area;
                    var sisalampo = alaPohja.InTemp ?? _attrs.InTemp; // TODO: overridable attribute
                    Q += (Uarvo * pAla * (sisalampo - Tmaa_kuukausi) * HoursInMonth(kuukausi)) / 1000;
                }
                // kaikki alapohjat yhteensa
                //Quut.Add((int)kuukausi, Q);
                Debug.WriteLine($"[ERITE] Alapohjan johtumishavio {kuukausi.ToString()}: {Q} kWh");
            //}

            return Q;//Quut.Values.Sum();
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

        // 2.
        public double VuotoilmanLammitysenergiaPerVuosi()
        {
            var n50 = 4.0; // TODO: taulukosta, 1/h, per vuosikymmen
            var ikkunaAla = _attrs.Ikkunat.Sum(i => i.Area);
            var vaipanAlaJaAlapohja = 2 * _attrs.NetArea + _attrs.Ulkoseinat.Sum(u => u.Area) + ikkunaAla + _attrs.Ovet.Sum(o => o.Area);
            Debug.WriteLine($"[ERITE] vaipan ja alapohjan pinta-ala: {vaipanAlaJaAlapohja} m2");

            var kohteenIlmatilavuus = _attrs.NetVolume;

            var q50 = GetQ50(n50, vaipanAlaJaAlapohja, kohteenIlmatilavuus);

            var qv_vuotoilma = (q50 * vaipanAlaJaAlapohja) / (3600 * 35); //< todo: wtf is 35?
            Debug.WriteLine($"[ERITE] qv, vuotoilma: {qv_vuotoilma} m3/s");

            var att_Ts = _attrs.InTemp;
            foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            {
                var att_Tu = _OutdoorTemp[kuukausi];


                var Q_vuotoilma = (IlmanTiheys * IlmanOmLampKap * qv_vuotoilma * (att_Ts - att_Tu) * HoursInMonth(kuukausi)) / 1000;
                _Qvuotoilmat[kuukausi] = Q_vuotoilma;
            }

            // koko vuodelle
            return _Qvuotoilmat.Sum(qv => qv.Value);
        }

        private double GetPoistoIlmaVirta()
        {
            return _attrs.NetArea * _attrs.Ventilation.Ulkoilmavirta / 1000; // dm3 -> m3
        }

        // kerroin sähkö ??
        internal double IVNettotarvePartial(int kk)
        {
            // TODO: lähtöarvo, tulo-poisto tasapaino
            // todo: kuukausittaiset keskilämpötilat, per asuinpaikka
            // jotain se höpötti painovoimainen vs. koneellinen
            // TODO: lähtöarvo, LTO:n vuosihyötysuhde
            var kuukausi = kk.Kuukausi();

            var poistoilmavirta = GetPoistoIlmaVirta();
            // TODO: kerro 24/7 arvolla
            Debug.WriteLine($"[ERITE] poistoilmavirta: {poistoilmavirta} m3/s");
            var T_sisa = _attrs.InTemp;
            // TODO: 30 % taulukkoarvo, riippuu vuosiluvusta
            //       voi olla myös painovoimainen, nolla
            var scop = _attrs.Ventilation.LTO_COP ?? 0.30; // TODO: overridable attribute tjms.
            Debug.WriteLine($"[ERITE] LTO vuosihyotysuhde: {scop * 100} %.");

            var runFact = _attrs.Ventilation.RunningHours / 24;

            //var Q_iv_vuodelle = 0d;
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                var T_ulko = _OutdoorTemp[kuukausi];

                // lämmöntalteenotolla talteenotettu teho (tammikuu) kaava 3.12
                var theta = scop * runFact * IlmanTiheys * IlmanOmLampKap * poistoilmavirta * (T_sisa - T_ulko);

                // lämmöntalteenoton jälkeinen tuloilman keskimääräinen lämpötila (tammikuu)
                // Kaava 3.11
                var tuloilmavirta = poistoilmavirta;
                var weeFact = 1.0;
                var T_lto = T_ulko + (theta / (runFact * weeFact * IlmanTiheys * IlmanOmLampKap * tuloilmavirta));

                // Kaava 3.10
                var T_sp = _attrs.Ventilation.KorvausilmanLampo; // sisään puhallettava ilma e.g. 18'C
                var dT_puh = 0;//T_sisa - T_sp;
                var Q_iv = runFact * weeFact * IlmanTiheys * IlmanOmLampKap * tuloilmavirta * ((T_sp - dT_puh) - T_lto) *
                           HoursInMonth(kuukausi) / 1000;
                Debug.WriteLine($"[ERITE] {kuukausi.ToString()} LTO talteenotettu teho: {theta} W, LTO temp: {T_lto} C, Ilmanvaihdon lamm. nettotarve: {Q_iv} kWh.");
            //    Q_iv_vuodelle += Q_iv;
            //}
            // Kaava 3.14
            // 18C - 21C (öljylämmityksen kertoimella)

            // Q_iv (sähkön kertoimella)
            return Q_iv;
            //return Q_iv_vuodelle;
        }

        public double IVBrutto(int kk)
        {
            // piti tulla 148
            var kaikki = IVTuloilmanLammittaminen(kk);
            var lto = IVNettotarvePartial(kk);
            return kaikki - lto;
        }

        
        // kerroin öljy
        internal double IVTuloilmanLammittaminen(int kk)
        {
            var kuukausi = kk.Kuukausi();
            var T_sisa = _attrs.InTemp;
            //var T_sisaan = _attrs.Ventilation.KorvausilmanLampo;
            //var dT_vent = T_sisa - T_sisaan;
            var tuloilmavirta = GetPoistoIlmaVirta();

            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                var T_ulko = _OutdoorTemp[kuukausi];
                var Q_iv_korv = IlmanTiheys * IlmanOmLampKap * tuloilmavirta * (T_sisa - T_ulko) *
                           HoursInMonth(kuukausi) / 1000;
                Debug.WriteLine($"[ERITE] {kuukausi.ToString()} Korvausilman lämpenemisen lämpöenergian tarve: {Q_iv_korv} kWh.");
            //    _Q_iv_korvausilma_vuodelle[kuukausi] = Q_iv_korv;
            //}
            return Q_iv_korv;
            //return _Q_iv_korvausilma_vuodelle.Sum(k => k.Value);
        }

        private const int Hattu = 35; // kWh/m2-v
        private const int ThresholdHattu = 4200; // kWh

        internal double KayttoVedenVakioituKaytto()
        {
            var ala = _attrs.NetArea;
            // lämpimän käyttöveden tarve vuodessa

            var tarve = ala * Hattu;
            var tarveValittu = Math.Min(tarve, ThresholdHattu);
            Debug.WriteLine($"[ERITE] Käyttöveden lämmitysenergian tarve: {tarveValittu} kWh.");


            return tarveValittu;



        }

        public double LKVTarve(int kk)
        {
            var kuukausi = kk.Kuukausi();
            // TODO: kaava 6.5
            // laske energia...
            // TAulukko 6.4
            // siirron vuosihyötysuhde
            var taulukosta = 0.96;
            var varaajaHavio = 0;
            //var tot_kwht = 0d;
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                var kiertoHavio = LKVKierto(kuukausi);
                var kwht = (KayttoVedenVakioituKaytto() / taulukosta) * (DaysInMonth((int)kuukausi) / 365.0) + varaajaHavio + kiertoHavio;
                //tot_kwht += kwht;
                Debug.WriteLine($"[ERITE] {kuukausi.ToString()} LKV energia: {kwht} kWh.");
            //}
            return kwht;
        }

        public double Kohta5LVIPumputSahkontarve(int kk)
        {
            var kuukausi = kk.Kuukausi();
            // TODO: taulukko sähkökrääsää

            // IV:N sähkön kulutus
            // Ominaissähköteho
            // Taulukko 3. Ilmanvaihtojärjestelmä - Rakennusluvan vireilletulovuosi
            var NominalPower = 2.5; // kW/m2/s (Taulukko 3)
            var tuloilmavirta = GetPoistoIlmaVirta();
            var result1 = tuloilmavirta * NominalPower * HoursInMonth(kuukausi);
            Debug.WriteLine($"[ERITE] IV sähköenergia: {result1} kWh.");

            // vesikiertoisen lattialämmityksen sähkönkulutus
            // taulukko 9
            var mikaIhme = 2.5; // kWh/m2-v 
            var result2 = _attrs.NetArea * mikaIhme * (DaysInMonth((int)kuukausi) / 365.0);
            Debug.WriteLine($"[ERITE] LL sähköenergia: {result2} kWh.");

            // öljylämmityksen sähköntarvei (taulukko 10)
            var whot = 0.99; //kWh/m2/vuosi
            var result3 = _attrs.NetArea * (DaysInMonth((int)kuukausi) / 365.0);
            Debug.WriteLine($"[ERITE] ÖP sähköenergia: {result3} kWh.");

            // lämpimän käyttöveden kiertopumpun sähkönkulutus (kaava 6.7)
            var pumpunTeho = 30; // W
            var result4 = pumpunTeho * HoursInMonth(kuukausi) / 1000;
            Debug.WriteLine($"[ERITE] LKV kiertopumppu sähköenergia: {result4} kWh.");

            return result1 + result2 + result3 + result4;
        }

        public double ValaistusJaKulutussahko(int kuukausi)
        {
            // Valaistuksen ja kuluttajalaitteiden sähkönkulutus
            // 11§ Rakennuksen vakioitu käyttö

            // valaistus 6W/m2
            var valaisuts = 6; // W/m2
            var val_KA = 0.1;

            var kulutt = 3; // W/m2
            var kul_KA = 0.6; // käyttöaste

            //var tot_kwhs = 0d;
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                var tunnit = HoursInMonth((Constants.KK)kuukausi);

                var kwhs = _attrs.NetArea * (valaisuts * val_KA + kulutt * kul_KA) * tunnit / 1000;
            //    tot_kwhs += kwhs;
            //}
            Debug.WriteLine($"[ERITE] valaistus ja käyttösähkö: {kwhs} kWh.");
            return kwhs;
        }

        public double LampokuormaHenkiloista(int kk)
        {
            //
            var factor = 0.6;
            var power = 2; // W
            var tot_kwhs = 0d;
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                var kwhs = factor * power * _attrs.NetArea * HoursInMonth((Constants.KK)kk) / 1000;
                tot_kwhs += kwhs;
            //}
            Debug.WriteLine($"[ERITE] ihmisenergia: {tot_kwhs} kWh/a.");
            return tot_kwhs;
        }

        internal double LKVKierto(Constants.KK kuukausi)
        {
            var ala = _attrs.NetArea;

            // Kiertojohdon pituus taulukosta 6.7
            // TODO: to talo attributes
            var Llkv_omin = 0.2; // Kiertojohdon ominaispituus: Llkv, omin, m / m2
            // kiertojohdon eristys (taulukko 6.6)
            var Llkv_havio = 15; // kv, kiertohäviö, omin, W / m
            // TODO: varaajahäviöt pitäs laskee tähän
            // KOULU case, öljykattilan kanssa ei erillistä varaajaa, häviöt lasketaan erikseen.

            // kiertojohdon häviön teho
            var havioTeho = ala * Llkv_omin * Llkv_havio;
            //Debug.WriteLine($"[ERITE] LKV kierto häviö: {havioTeho} W.");

            //var tot_kwhs = 0d;
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{
                // kiertojohdon häviö tammikuussa
                var kwht = havioTeho * HoursInMonth(kuukausi) / 1000;
            //    tot_kwhs += kwht;
            //}
            Debug.WriteLine($"[ERITE] {kuukausi.ToString()} LKV kierto häviö: {havioTeho} W, {kwht} kWh.");
            return kwht;
        }

        public double Kohta6IkkunoidenKauttaTulevaSateilyEnergia(int kk)
        {
            // TODO:  taulukosta..
            var gKoht = Constants.GKohtisuoraOletus;
            var g = 0.9 * gKoht;
            var fLapaisy = Constants.FLapaisyOletus;

            var gSateilyPysty = 12.9; // TODO: taulukko s.18/19 (ETELA)
            var ikkunaAlaEtela = 11.1;

            // (KAAVA 5.4
            // TODO: ikkunan
            var Qaur = gSateilyPysty * fLapaisy * ikkunaAlaEtela * g;
            Debug.WriteLine($"[ERITE] Ikkuna lämpökuorma etelä: {Qaur} kWh.");
            // TODO: joka ilmansuuntaan joka kuukaudelle.. jep

            return Qaur; // + muut suunnat
        }

        public double Kohta7LampokuormienHyodyntaminen(int kk)
        {
            Constants.KK kuukausi = (Constants.KK)kk;

            // johtumishäviöt, tammikuu (kts. Excel)
            var Qjoht = /*Qylapohja + Qikk + Qovet + Qulkoseina + Qalapohja*/ 1948.0;

            // Olemassa olevan rakennuksen yhteydessä voidaan laskea 10% johtumishäviöstä
            // kylmäsilloille. Uudiskohteelle lasketaan reunaviivat tms.
            var kylmasilta = 0.10 * Qjoht;

            //var tot_bs_response = 0d;
            //// TODO: tehdaanko kuukausittain, vai kokonaisvahennys
            //foreach (Constants.KK kuukausi in Enum.GetValues(typeof(Constants.KK)))
            //{

                // Lasketaan (kaava 3.2) Qtila = Qjoht + Qvuotoilma + Qiv,tuloilma + Qiv,korvausilma
                var Qvuoto = _Qvuotoilmat[kuukausi];// 271d; // tODO: tallenna välitulos per kuukausi
                var QivTulo = 157d; // TODO: ^^sama
                var QivKorvaus = 0d; //< todo: onko se tulo tai korvaus
                var Qtila = Qjoht + kylmasilta + Qvuoto + QivTulo + QivKorvaus;

                // Note. tuloilma tulee iv koneesta
                //       korvausilma tulee ikkunan raosta tai tuloilmaventtiilista

                // Rakennuksen tilojen ominaislampohavio
                double Htila = 0d;
            var deltaT = (_attrs.InTemp - _OutdoorTemp[kuukausi]);
            if (0 == deltaT) deltaT = 0.01; // valitse pieni

                Htila = Qtila / (deltaT * HoursInMonth(kuukausi)) * 1000;


                // valitaan Crak = 70 Wh/m2K (taulukko 5.6)
                var Crak = 70d; // TODO: katso taulukosta
                                // Rakennuksen aikavakio
                var Tau = (Crak * _attrs.NetArea) / (Htila);
                Debug.WriteLine($"[ERITE] Aikavakio: {Tau} h");
                // suhdeluku gamma (kaava 5.4)

                // Lämpökuormat tammikuussa:
                // - henkilöt, 131,2 kWh
                // - valaistus+sähkö, 263 kWh
                // - lämp.veden kierto 328 kWh (kts. 1010/2017, 18§) kerroin!
                // - aurinko ikkunoista
                var henkilot = LampokuormaHenkiloista((int)kuukausi);
                var valaistus = ValaistusJaKulutussahko((int)kuukausi);
                var kierto = 1.5 * LKVKierto(kuukausi);
                var aurinko = Kohta6IkkunoidenKauttaTulevaSateilyEnergia((int)kuukausi);

                var lampoKuorma = henkilot + valaistus + kierto + aurinko;

                // Lampokuorman suhde lampohavioon
                var gamma = lampoKuorma / 2571d; // (5.14)
                                                 // Numeerinen parametri a
                var a = 1 + Tau / 15; // (5.13)
                                      // lämpökuorman hyödyntämisaste tassa kuussa
                var nlampo = (1 + Math.Pow(gamma, a)) / (1 + Math.Pow(gamma, a + 1));
                Debug.WriteLine($"[ERITE] Lampokuorman hyodyntamisaste kk: {kuukausi.ToString()}, arvo: {nlampo}");

                var Qlamm_tilat_netto = 2571d - nlampo * 616.2; //< todo mitanaaoli? 
                                                                //tot_bs_response += Qlamm_tilat_netto;
                                                                //}
                                                                //return tot_bs_response;
            return Qlamm_tilat_netto;
        }

        public double Kohta8VaraavaTulisijaJaILPPerVuosi()
        {
            var ostoUuni = Kohta8VaraavaTulisijaPerVuosi();
            var ostoILP = Kohta8ILPPerVuosi();
            return ostoUuni + ostoILP;
        }

        internal double Kohta8VaraavaTulisijaPerVuosi()
        {
            // TODO: add varaava tulisija into house attrs

            // VTT määritelmä varaavalle tulisijalle, std SFS-EN 15250
            // t_tulisijanpinta - t_ymparisto = 100 % -> min. 4 h -> 50 %

            // CE-merkinta ja valmistajan ilmoittama hyotysuhde
            var coeff = 0.6; //< TODO: asetus, tai valmistajan arvo

            // Tulisijan max.energian luovutus
            var MaxOutput = 3000d; // vakio. vuodessa!
            // -> ostoenergian maara
            var ostoEn = MaxOutput / coeff; // kWh
            Debug.WriteLine($"[ERITE] Tulisijan ostoenergian maara: {ostoEn} kWh");
            return ostoEn;
        }

        internal double Kohta8ILPPerVuosi()
            {
                // ILP:stä,  1048/2017
                // taulukko rakennusvuosi, max teho, max teho per neliot

                // rakennuslupa vireille 2 vuotta ennen valmistumista (nyt saatiin vm. 2004)
                // ILP max luovutus tilaan 3000 kWh (TODO: taulukosta 15)
                var ILPMaxOutput = 3000d;
            var ostoSahko = ILPMaxOutput / ILP_COP;
            Debug.WriteLine($"[ERITE] ILP ostoenergian maara: {ostoSahko} kWh");

            // Ei riita. Energiankulutuksen laskentaohjeet luvut 6-7

            return ostoSahko;
        }

        public double Kohta9LammitysjarjestelmanEnergiankulutus(int kk)
        {
            var latt_tilat_brutto = Kohta7LampokuormienHyodyntaminen(kk);
            var tulisija = 3000d; //< TODO: naa maksimit tuli vuosiluvun mukaan
            var ILP = 3000d;
            var QLamm_tilat_netto = latt_tilat_brutto - tulisija * (DaysInMonth(kk) / 365d) - ILP * (DaysInMonth(kk) / 365d);
            QLamm_tilat_netto = Math.Max(0d, QLamm_tilat_netto);
            Debug.WriteLine($"[ERITE] lamm_tilat_netto: {QLamm_tilat_netto} kWh");

            // Tilojen lammonjakojarjestelman lampoenergian tarve
            // - vesikiertoisen lattialammityksen vuosihyotysuhde (Taulukko 6.1)
            var eff_ll = 0.8; // TODO: taulukosta, asetuksiin lammonjaon tyyppi tjms. luokka

            var Qlammitys_tilat = QLamm_tilat_netto / eff_ll;
            Debug.WriteLine($"[ERITE] Kattilasta tarvitaan lattialampoon: {Qlammitys_tilat} kWh");

            // Oljykattilan ostoenergian tarve
            var eff_oljy = 0.81; // TODO. parameterize by lammitysmuoto
            var Qvesi = LKVTarve(kk);
            var Qlammitys_oljy = (Qlammitys_tilat + Qvesi) / eff_oljy;
            // Varaavan tulisijan ostoenergian tarve
            var Quuni = Kohta8VaraavaTulisijaPerVuosi() * (DaysInMonth(kk) / 365d);
            // ILP ostoenergia tassa kuussa
            var QILP = Kohta8ILPPerVuosi() * (DaysInMonth(kk) / 365d);
            Debug.WriteLine($"[ERITE] Ostoenergia Oljy: {Qlammitys_oljy} kWh, uuni {Quuni} kWh, ILP: {QILP}");

            // TODO: sähkö 982, öljy 3092, ... mistä sähkö? kaikki kulutus sinne
            // ks. Excelistä..

            // tassa vasta energiamuodon kerroin
            var pumput = Kohta5LVIPumputSahkontarve(kk);
            var kokonais_sahko = (QILP + pumput) * 1.2;
            var kokonais_puu = Quuni * 0.5;
            Debug.WriteLine($"[ERITE] Kokonaisenergia Oljy: {Qlammitys_oljy} kWh, Sahko: {kokonais_sahko} kWh, Puu: {kokonais_puu}");

            // TODO: palauta lista parempia olioita..
            var painotettu = Qlammitys_oljy + kokonais_sahko + kokonais_puu;

            return painotettu;
        }

        // m3/h*m2
        private double GetQ50(double n50, double alaVaippaKaikki, int ilmatilavuus)
        {
            var ret = (n50/alaVaippaKaikki)*ilmatilavuus;
            Debug.WriteLine($"[ERITE] Q50: {ret} m3/h*m2");
            return ret;
        }

        private int HoursInMonth(Constants.KK month)
        {
            return 24 * DaysInMonth((int)month);
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
