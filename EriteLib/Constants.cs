using System;
using System.Collections.Generic;
using System.Text;

namespace EriteLib
{
    class Constants
    {
        internal const double GKohtisuoraOletus = 0.6;
        internal const double FLapaisyOletus = 0.5;

        enum IkkunaTyyppi
        {
            YksinkertainenLasitus,
            KaksinkertainenLasitus,
            YksipuitteinenKolmilasinenIkkuna,
            EristyslasiJaErillislasi,
            EristyslasiMatalaemissiivinenJaErillislasi
        }

        static readonly Dictionary<IkkunaTyyppi, double> Gkohtisuora = new Dictionary<IkkunaTyyppi, double>
        {
           {IkkunaTyyppi.YksinkertainenLasitus, 0.85 }                                  ,
           {IkkunaTyyppi.KaksinkertainenLasitus, 0.75                                 } ,
           {IkkunaTyyppi.YksipuitteinenKolmilasinenIkkuna, 0.70                     } ,
           {IkkunaTyyppi.EristyslasiJaErillislasi, 0.65                               } ,
           {IkkunaTyyppi.EristyslasiMatalaemissiivinenJaErillislasi, 0.55 }
        };


        // Auringon kokonaissäteilyenergia pystypinnoille eri ilmansuuntiin
        enum Ilmansuunta
        {
            P, Ko, I, Ka, E, Lo, L, Lu
        }

        internal enum KK
        {
            Tammikuu  = 1,
            Helmikuu  = 2,
            Maaliskuu = 3,
            Huhtikuu  = 4,
            Toukokuu  = 5,
            Kesäkuu   = 6,
            Heinäkuu  = 7,
            Elokuu    = 8,
            Syyskuu   = 9,
            Lokakuu   = 10,
            Marraskuu = 11,
            Joulukuu  = 12
        }

        // Rakennuksen energiankulutuksen ja lämmitystehontarpeen laskenta 20122017 vain korostukset.PDF
        // Sivu 20, Taulukko 3.4
        // "Alapohjan alapuolisen maan kuukausittaisen keskilämpötilan ja vuotuisen keskilämpötilan ero."
        internal static readonly Dictionary<KK, int> dT_maa = new Dictionary<KK, int>
        {
            { KK.Tammikuu, 0},
            { KK.Helmikuu , -1},
            { KK.Maaliskuu, -2},
            { KK.Huhtikuu , -3},
            { KK.Toukokuu , -3},
            { KK.Kesäkuu  , -2},
            { KK.Heinäkuu , 0},
            { KK.Elokuu   , 1},
            { KK.Syyskuu  , 2},
            { KK.Lokakuu  , 3},
            { KK.Marraskuu, 3},
            { KK.Joulukuu , 2}
        };

        /*
        static readonly Dictionary<int, Dictionary<Ilmansuunta, double>> SateilyPysty = new Dictionary<int, Dictionary<Ilmansuunta, double>>
        {
            {KK.Tammikuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  6,2 }, Ilmansuunta.Ko, 4,7 3,8 9,5 12,9 9,5 3,8 4,7
            {KK.Helmikuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  17,3}, Ilmansuunta.Ko, 13,8 15,6 31,0 41,4 30,9 15,6 14,0
            {KK.Maaliskuu,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  40,3}, Ilmansuunta.Ko, 38,1 48,5 75,1 89,5 69,4 43,7 36,9
            {KK.Huhtikuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  43,9}, Ilmansuunta.Ko, 56,3 79,9 101,1 107,3 101,6 80,6 56,8
            {KK.Toukokuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  57,8}, Ilmansuunta.Ko, 82,1 112,8 123,3 116,0 117,5 104,5 76,3
            {KK.Kesäkuu  ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  70,6}, Ilmansuunta.Ko, 87,9 109,6 109,9 101,6 110,9 111,2 89,1
            {KK.Heinäkuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  66,3}, Ilmansuunta.Ko, 91,1 118,8 123,1 115,5 128,6 122,7 91,2
            {KK.Elokuu   ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  50,0}, Ilmansuunta.Ko, 66,4 91,8 106,0 100,4 92,8 78,8 61,1
            {KK.Syyskuu  ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  32,9}, Ilmansuunta.Ko, 37,5 56,5 83,9 100,5 87,3 59,3 38,1
            {KK.Lokakuu  ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  17,9}, Ilmansuunta.Ko, 15,6 17,5 28,3 37,0 30,0 18,8 15,7
            {KK.Marraskuu,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  7,2 }, Ilmansuunta.Ko, 5,5 5,1 12,3 16,8 12,3 5,1 5,6
            {KK.Joulukuu ,{ new Dictionary<Ilmansuunta, double> { Ilmansuunta.P,  4,2 }, Ilmansuunta.Ko, 3,2 2,6 8,4 11,8 8,8 2,9 3,2
        };
        */
    }
}
