using System;
using System.Diagnostics;

namespace EriteLib
{
    public class EriteLaskuri
    {
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

            var pAla = 147.0; // m2
            var sisalampo = 21.0; // C
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

            var att_Ts = 21.0;
            var att_Tu = -3.97;


            var Q_vuotoilma = (IlmanTiheys * IlmanOmLampKap * qv_vuotoilma * (att_Ts - att_Tu) * HoursInMonth(1)) / 1000;

            return Q_vuotoilma;
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
                    return 24 * 31;
                }
                case 4:
                {
                    return 24 * 28;
                }
                default:
                {
                    return 24 * 30;
                }
            }
        }
    }
}
