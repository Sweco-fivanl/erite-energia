using System;
using System.Collections.Generic;
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
    internal class OstoEnergia
    {
        private EnergiaMuoto _energiaMuoto;
        //private double _laiteSahko;

        internal void SetHeatingDemand(double tarve, double kerroin)
        {
            _energiaMuoto = new EnergiaMuoto { KulutusAnnual = tarve, Kerroin = kerroin };
        }

        //internal void SetLaiteSahko(double vuodelle)
        //{
        //    _laiteSahko = vuodelle;
        //}

        internal double OstoEnergianMaara()
        {
            return /*_laiteSahko +*/ _energiaMuoto.GetOstettava();
        }
    }

    internal class EnergiaMuoto
    {
        public double Kerroin { get; set; }
        public double KulutusAnnual { get; set; }
        public double GetOstettava()
        {
            return Kerroin * KulutusAnnual;
        }
    }
}
