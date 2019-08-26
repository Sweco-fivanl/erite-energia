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
    }
}
