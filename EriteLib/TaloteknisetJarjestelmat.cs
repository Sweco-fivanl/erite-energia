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
            //TODO: jne.. var listaus = new List<LammitysLaite>();
            return /*_laiteSahko +*/ new[] { _mainHeating }.ToList();
        }
    }

    internal abstract class LammitysLaite
    {
        private double _energiamuodonKerroin;
        private double _energiaAnnual;
        private double _polttoaineHyotysuhde;

        public LammitysLaite(double energia, double kerroin, double hyotysuhde)
        {
            _energiamuodonKerroin = kerroin;
            _energiaAnnual = energia;
            _polttoaineHyotysuhde = hyotysuhde;
        }

        public double GetOstettavaKwh()
        {
        //TODO: paalammityslaitteen energiakulutuksen vahennys
            return _energiaAnnual / _polttoaineHyotysuhde;
        }

        public double GetEnergiamuodonKerroin()
        {
            return _energiamuodonKerroin;
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
}
