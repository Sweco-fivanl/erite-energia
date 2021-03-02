using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EriteLib
{
   public class OsaLaskuri
   {
      private Ulkovaipat _partConfig;

      // Use standard numeric format specifiers.
      private const string Specifier = "G";
      private static readonly NumberFormatInfo Nfi = new NumberFormatInfo
      {
         NumberDecimalSeparator = ".",
         NumberGroupSeparator = ""
      };

      public void SetConfig(Ulkovaipat attributes)
      {
         _partConfig = attributes;
      }

      public List<KerrosRakenne> OsaListaus()
      {
         if (null == _partConfig) throw new Exception("Osalistaus json puuttuu");

         var listaus = new List<KerrosRakenne>();
         foreach (var rakenneTieto in _partConfig.rakennetyypit)
         {
            // uusi rakennetyyppi
            var rakennetyyppi = new KerrosRakenne{Name=rakenneTieto.nimi};
            foreach (var kerrosTieto in rakenneTieto.kerrokset)
            {
               Materiaali materiaali = null;
               if (!TryFromKirjasto(kerrosTieto.kirjasto, out materiaali))
               {
                  materiaali = new Materiaali(kerrosTieto.nimi, Evaluate(kerrosTieto.lambda));
               }

               Materiaali ksMateriaali = null;
               if (null != kerrosTieto.kylmasilta)
               {
                  if (!TryFromKirjasto(kerrosTieto.kylmasilta.kirjasto, out ksMateriaali))
                  {
                     ksMateriaali = new Materiaali(kerrosTieto.kylmasilta.nimi, Evaluate(kerrosTieto.kylmasilta.lambda));
                  }
               }

               if (null == ksMateriaali)
               {
                  rakennetyyppi.LisaaKerros(materiaali, kerrosTieto.d);
               }
               else
               {
                  rakennetyyppi.LisaaKerros(materiaali, kerrosTieto.d, ksMateriaali, kerrosTieto.kylmasilta.osuus);
               }
            }
            // listalle
            listaus.Add(rakennetyyppi);
         }

         return listaus;
      }

      private bool TryFromKirjasto(string avain, out Materiaali materiaali)
      {
         var kirjasto = new LampoLaskut.Lbd();
         var amountField = LampoLaskut.Lbd.LataaKirjastosta(avain);
         if (null != amountField)
         {
            materiaali = amountField;
            return true;
         }
         materiaali = null;
         return false;
      }

      // matemaattinen lauseke
      public static double Evaluate(string expression)
      {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
   }
}
