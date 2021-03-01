using System;
using System.Collections.Generic;
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
      public static double Evaluate(string expr)
      {
         expr = expr.ToLower();
         expr = expr.Replace(",", ".");
         expr = expr.Replace(" ", "");
         expr = expr.Replace("true", "1");
         expr = expr.Replace("false", "0");

         Stack<String> stack = new Stack<String>();

         string value = "";
         for (int i = 0; i < expr.Length; i++)
         {
            String s = expr.Substring(i, 1);
            // pick up any doublelogical operators first.
            if (i < expr.Length - 1)
            {
               String op = expr.Substring(i, 2);
               if (op == "<=" || op == ">=" || op == "==")
               {
                  stack.Push(value);
                  value = "";
                  stack.Push(op);
                  i++;
                  continue;
               }
            }

            char chr = s.ToCharArray()[0];

            if (!char.IsDigit(chr) && chr != '.' && value != "")
            {
               stack.Push(value);
               value = "";
            }
            if (s.Equals("("))
            {
               string innerExp = "";
               i++; //Fetch Next Character
               int bracketCount = 0;
               for (; i < expr.Length; i++)
               {
                  s = expr.Substring(i, 1);

                  if (s.Equals("(")) bracketCount++;

                  if (s.Equals(")"))
                  {
                     if (bracketCount == 0) break;
                     bracketCount--;
                  }
                  innerExp += s;
               }
               stack.Push(Evaluate(innerExp).ToString(Specifier, Nfi));
            }
            else if (s.Equals("+") ||
                     s.Equals("-") ||
                     s.Equals("*") ||
                     s.Equals("/") ||
                     s.Equals("<") ||
                     s.Equals(">"))
            {
               stack.Push(s);
            }
            else if (char.IsDigit(chr) || chr == '.')
            {
               value += s;

               if (value.Split('.').Length > 2)
                  throw new Exception("Invalid decimal.");

               if (i == (expr.Length - 1))
                  stack.Push(value);

            }
            else
            {
               throw new Exception("Invalid character.");
            }

         }
         double result = 0;
         List<String> list = stack.ToList<String>();
         for (int i = list.Count - 2; i >= 0; i--)
         {
            if (list[i] == "/")
            {
               list[i] = (Convert.ToDouble(list[i - 1], Nfi) / Convert.ToDouble(list[i + 1],Nfi)).ToString(Specifier, Nfi);
               list.RemoveAt(i + 1);
               list.RemoveAt(i - 1);
               i -= 2;
            }
         }

         for (int i = list.Count - 2; i >= 0; i--)
         {
            if (list[i] == "*")
            {
               list[i] = (Convert.ToDouble(list[i - 1], Nfi) * Convert.ToDouble(list[i + 1], Nfi)).ToString(Specifier, Nfi);
               list.RemoveAt(i + 1);
               list.RemoveAt(i - 1);
               i -= 2;
            }
         }
         for (int i = list.Count - 2; i >= 0; i--)
         {
            if (list[i] == "+")
            {
               list[i] = (Convert.ToDouble(list[i - 1], Nfi) + Convert.ToDouble(list[i + 1], Nfi)).ToString(Specifier, Nfi);
               list.RemoveAt(i + 1);
               list.RemoveAt(i - 1);
               i -= 2;
            }
         }
         for (int i = list.Count - 2; i >= 0; i--)
         {
            if (list[i] == "-")
            {
               list[i] = (Convert.ToDouble(list[i - 1], Nfi) - Convert.ToDouble(list[i + 1], Nfi)).ToString(Specifier, Nfi);
               list.RemoveAt(i + 1);
               list.RemoveAt(i - 1);
               i -= 2;
            }
         }
         stack.Clear();
         for (int i = 0; i < list.Count; i++)
         {
            stack.Push(list[i]);
         }
         while (stack.Count >= 3)
         {
            double right = Convert.ToDouble(stack.Pop(), Nfi);
            string op = stack.Pop();
            double left = Convert.ToDouble(stack.Pop(), Nfi);

            if (op == "<") result = (left < right) ? 1 : 0;
            else if (op == ">") result = (left > right) ? 1 : 0;
            else if (op == "<=") result = (left <= right) ? 1 : 0;
            else if (op == ">=") result = (left >= right) ? 1 : 0;
            else if (op == "==") result = (left == right) ? 1 : 0;

            stack.Push(result.ToString(Specifier, Nfi));
         }

         return Convert.ToDouble(stack.Pop(), Nfi);
      }
   }
}
