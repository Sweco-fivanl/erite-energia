using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EriteLib
{
   public static class LampoLaskut
   {
      public static readonly Dictionary<string, double> Lambdas = new Dictionary<string, double>
        {
            { "Puu", 0.12 },
            { "Kipsilevy", 0.21 },
            { "Villa", 0.033 },
            { "Tuulensuojavilla", 0.031 },
            { "Tiili", 0.5 },
        };

      // Otettu mm. C4 normeeratut
      public struct Lbd
      {
         public static Materiaali Betoni = new Materiaali("Betoni", 2.0);
         public static Materiaali Puu = new Materiaali("Puu                  ", 0.12);
         public static Materiaali Kipsilevy = new Materiaali("Kipsilevy            ", 0.21);
         public static Materiaali Lastulevy = new Materiaali("Lastulevy            ", 0.13);
         public static Materiaali KL33 = new Materiaali("KL33                 ", 0.033);
         public static Materiaali Mineraalivilla = new Materiaali("Mineraalivilla       ", 0.045);
         public static Materiaali Ekovilla = new Materiaali("Ekovilla       ", 0.039);
         public static Materiaali Tuulensuojavilla = new Materiaali("Tuulensuojavilla     ", 0.031);
         public static Materiaali Tiili = new Materiaali("Tiili                ", 0.5);
         public static Materiaali PuukuitulevyBitumi = new Materiaali("PuukuitulevyBitumi   ", 0.065);
         public static Materiaali PuukuitulevyHuokoinen = new Materiaali("PuukuitulevyHuokoinen", 0.055);
         public static Materiaali Sahanpuru = new Materiaali("Sahanpuru            ", 0.08);
         public static Materiaali LaastiKalkkisementti = new Materiaali("Laasti (kalkkisementti)", 0.80);
         public static Materiaali Kevytsorabetoni = new Materiaali("Kevytsorabetoni", 0.24);
         public static Materiaali EPS = new Materiaali("solumuovilevy, paisutettu polystyreeni", 0.041);
         public static Materiaali Laatat = new Materiaali("Tiilet, keraaminen/posliini", 1.30);

         public static Materiaali LataaKirjastosta(string name)
         {
            switch (name)
            {
               case "Betoni":
                  return Betoni;
               case "Puu":
                  return Puu;
               case "Kipsilevy":
                  return Kipsilevy;
               case "Lastulevy":
                  return Lastulevy;
               case "KL33":
                  return KL33;
               case "Mineraalivilla":
                  return Mineraalivilla;
               case "Ekovilla":
                  return Ekovilla;
               case "Tuulensuojavilla":
                  return Tuulensuojavilla;
               case "Tiili":
                  return Tiili;
               case "PuukuitulevyBitumi":
                  return PuukuitulevyBitumi;
               case "PuukuitulevyHuokoinen":
                  return PuukuitulevyHuokoinen;
               case "Sahanpuru":
                  return Sahanpuru;
               case "LaastiKalkkisementti":
                  return LaastiKalkkisementti;
               case "Kevytsorabetoni":
                  return Kevytsorabetoni;
               case "EPS":
                  return EPS;
               case "Laatat":
                  return Laatat;
               default:
                  Debug.WriteLine($"[ERITE] Materiaali '{name}' ei toteutettu hakuun.");
                  return null;
            }
         }
      }
   }
}
