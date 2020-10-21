using EriteLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EriteLib
{
    internal struct Hyotysuhde
    {
        public const double OljyKattila = 0.81;
        public const double VaraavaUuni = 0.6; // CE-merkinta ja valmistajan ilmoittama hyotysuhde (tai asetus)
        public const double ILP_SCOP = 2.8; // CE-merkinta ja valmistajan ilmoittama hyotysuhde (tai asetus)
    }

    internal struct Kerroin
    {
        public const double Sahko = 1.20;
        public const double Oljy = 1.00;
        public const double Kaukolampo = 0.50;
        public const double Puu = 0.50;
    }

    // TODO: make list of EnergiaMuoto
    internal class TaloteknisetJarjestelmat
    {
        private LammitysLaite _mainHeating;
        private List<LammitysLaite> _lisaLammittimet;
        //TODO: private List<SahkoLaite> _muutLaitteet;
        //private double _laiteSahko;

        internal void SetMainHeating(LammitysLaite paaLammitys)
        {
            _mainHeating = paaLammitys;
        }

        internal void AddHeater(LammitysLaite secondary)
        {
            _lisaLammittimet = _lisaLammittimet ?? new List<LammitysLaite>();
            _lisaLammittimet.Add(secondary);
        }

        internal List<LammitysLaite> OstoEnergianMaarat()
        {
            double vahennys = 0;
            foreach(var lisaLammitin in _lisaLammittimet)
            {
                vahennys += lisaLammitin.TuottoKwhA();
            }
            _mainHeating.SetVahennys(vahennys);
            var laitteet = new[] { _mainHeating }.ToList();
            laitteet.AddRange(_lisaLammittimet);

            // palauta lammityslaitteet, paalammittimen tuotosta vahennetty muut
            return laitteet;
        }
    }

    internal abstract class LammitysLaite
    {
        private double _energiamuodonKerroin;
        private double _energiaAnnual;
        private double _polttoaineHyotysuhde;
        private double _vahennys = 0;

        public LammitysLaite(double energia, double kerroin, double hyotysuhde)
        {
            _energiamuodonKerroin = kerroin;
            _energiaAnnual = energia;
            _polttoaineHyotysuhde = hyotysuhde;
        }

        public double TuottoKwhA()
        {
            return _energiaAnnual;
        }

        public double GetOstettavaKwh()
        {
            // paalammityslaitteen energiakulutuksen vahennys muista, takka, ILP..
            return Math.Max(0, _energiaAnnual - _vahennys) / _polttoaineHyotysuhde;
        }

        public double GetEnergiamuodonKerroin()
        {
            return _energiamuodonKerroin;
        }

        public void SetVahennys(double kwn_a)
        {
            _vahennys = kwn_a;
        }

        public abstract double GetLisaSahkonKulutus();
    }

    internal class OljyKattila : LammitysLaite
    {
        private double _nettoAla;

        public OljyKattila(double energia, TaloAttributes attrs)
            : base(energia, Kerroin.Oljy, Hyotysuhde.OljyKattila)
        {
            _nettoAla = attrs.NetArea;
        }

        public override double GetLisaSahkonKulutus()
        {
            // öljylämmityksen sähköntarvei (taulukko 10)
            var whot = 0.99; //kWh/m2/vuosi
            var result3 = _nettoAla * whot;
            Debug.WriteLine($"[ERITE] ÖP sähköenergia: {result3} kWh.");
            return result3;
        }
    }

    internal class VaraavaUuni : LammitysLaite
    {
        public VaraavaUuni(/*double valmistajanArvo = -1*/)
            : base(3000d, Kerroin.Puu, Hyotysuhde.VaraavaUuni)
        {
        }

        public override double GetLisaSahkonKulutus()
        {
            return 0;
        }
    }

    internal class IlmaLampoPumppu : LammitysLaite
    {
        private double _nettoAla;

        public IlmaLampoPumppu(TaloAttributes attrs /*double valmistajanSCOP = -1*/)
            : base(3000d, Kerroin.Puu, Hyotysuhde.VaraavaUuni)
        {
            _nettoAla = attrs.NetArea;
        }

        public override double GetLisaSahkonKulutus()
        {
            // sahkon osto tulee kantaluokasta
            return 0;
        }
    }
}
