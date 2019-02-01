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
