using System;
using System.Collections.Generic;
using System.Text;

namespace EriteLib
{
    internal static class Apufunktiot
    {
        internal static Constants.KK Kuukausi(this int kk)
        {
            if (kk < 1 || kk > 12) throw new ArgumentOutOfRangeException("Kuukausi on valilla 1-12");
            return (Constants.KK)kk;
        }

        internal static double Vuotuinen(Func<int, double> kuukausittainen)
        {
            var vuotuinen = 0d;
            for(int i=1; i<=12; i++)
            {
                vuotuinen += kuukausittainen(i);
            }
            return vuotuinen;
        }
    }
}
