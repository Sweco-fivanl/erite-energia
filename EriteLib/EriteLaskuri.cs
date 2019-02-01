using System;
using System.Diagnostics;

namespace EriteLib
{
    public class EriteLaskuri
    {
        public int LaskeJotain()
        {
            return 0;
        }


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
            var Q = (Uarvo * pAla * (sisalampo - Tmaa_tammikuu) * 744 /*h*/ )/1000;


            return Q;
        }
    }
}
