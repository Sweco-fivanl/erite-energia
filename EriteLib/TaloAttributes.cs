using System;
using System.Collections.Generic;
using System.Text;

namespace EriteLib
{
   public class TaloAttributes
   {
      public List<RakennusOsa> Ulkoseinat { get; set; }
      public List<RakennusOsa> Ylapohjat { get; set; }
      public List<RakennusOsa> Alapohjat { get; set; }
      public List<RakennusOsa> Ovet { get; set; }
      public List<Ikkuna> Ikkunat { get; set; }
      public double InTemp { get; set; }
      public double NetArea { get; set; }
      public int NetVolume { get; set; }
      public Ventilation Ventilation { get; set; }
   }

   public class Ventilation
   {
      public int RunningHours { get; set; }
      public double Ulkoilmavirta { get; set; }
      public double? LTO_COP { get; set; }
      public double KorvausilmanLampo { get; set; }
   }

   public class RakennusOsa
   {
      public String Kuvaus { get; set; }
      public double Area { get; set; }
      public double UArvo { get; set; }
      public double? InTemp { get; set; }
   }

   public enum Ilmansuunta
   {
      Pohjoinen,
      Itä,
      Etelä,
      Länsi
   }

   public class Ikkuna : RakennusOsa
   {
      public Ilmansuunta Ilmansuunta { get; set; }
      /*
      private Dictionary<Ilmansuunta, List<RakennusOsa>> _ilmansuuntiin;

      public Dictionary<Ilmansuunta, List<RakennusOsa>> Ilmansuuntiin
      {
          get
          {
              return _ilmansuuntiin = _ilmansuuntiin ?? new Dictionary<Ilmansuunta, List<RakennusOsa>>();
          }
          private set
          {
              _ilmansuuntiin = value;
          }
      }
      */
   }


   // -----------------------------------------------
   // lambda jsonit
   // -----------------------------------------------


   public class Ulkovaipat
   {
      public string nimi { get; set; }
      public List<Rakennetyyppi> rakennetyypit { get; set; }
   }

   public class Rakennetyyppi
   {
      public string nimi { get; set; }
      public string area { get; set; }
      public List<KerrosTieto> kerrokset { get; set; }
   }

   public class KerrosTieto
   {
      public string kirjasto { get; set; }
      public double d { get; set; }
      public string nimi { get; set; }
      public string lambda { get; set; }
      public KerrosTieto kylmasilta { get; set; }
      public double osuus { get; set; } = 1;
   }

}
