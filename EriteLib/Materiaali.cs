using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EriteLib
{
    public class Materiaali
    {
        public double Lambda { get; set; }
        public double Thickness { get; set; }
        public double GetR()
        {
            if (0 == Lambda) return 0;
            return Thickness / Lambda;
        }
    }

    public class KerrosRakenne
    {
        public double Rsi { get; set; } = 0.130;
        public double Rse { get; set; } = 0.040;
        private List<MateriaaliKerros> _kerrokset;
        public List<MateriaaliKerros> Kerrokset
        {
            get
            {
                if (null == _kerrokset) _kerrokset = new List<MateriaaliKerros>();
                return _kerrokset;
            }
        }
        public void LisaaKerros(double lambda, double d)
        {
            Kerrokset.Add(new MateriaaliKerros { Materiaali = new Materiaali { Lambda = lambda, Thickness = d } });
        }

        public void LisaaKerros(double lambda, double d, double kylmaLambda, double osuus)
        {
            Kerrokset.Add(new MateriaaliKerros
            {
                Materiaali = new Materiaali { Lambda = lambda, Thickness = d },
                Kylmasilta = new Kylmasilta
                {
                    Aine = new Materiaali { Lambda = kylmaLambda, Thickness = d },
                    Osuus = osuus
                }
            });
        }

        public double Laske_U()
        {
            // yla- ja alalikiarvot
            var RTa = Rsi; // pintavastus
            var RTb = Rsi;
            var bOsuus = 0d;
            bool kylmasiltoja = false;

            foreach (var mat in Kerrokset)
            {
                RTa += mat.Materiaali.GetR();
                if (mat.Kylmasilta != null)
                {
                    if (kylmasiltoja) throw new Exception("Vain yksi kylmasilta tuettu");
                    kylmasiltoja = true;
                    RTb += mat.Kylmasilta.Aine.GetR();
                    bOsuus = mat.Kylmasilta.Osuus;
                }
                else
                {
                    RTb += mat.Materiaali.GetR();
                }
            }
            RTa += Rse;
            RTb += Rse;
            var fi_RTa = (1 - bOsuus) / RTa;
            var fi_RTb = bOsuus / RTb;
            var RTinv = fi_RTa + fi_RTb;
            var ylalikiarvo_RT = 1 / RTinv;
            Debug.WriteLine($"[ERITE] Ylalikiarvo R'T: {ylalikiarvo_RT} m2K/W");

            var RppT = Rsi; // pintavastus
            foreach (var mat in Kerrokset)
            {
                if (mat.Kylmasilta != null)
                {
                    var f1_R1 = (1 - mat.Kylmasilta.Osuus) / mat.Materiaali.GetR();
                    var f2_R2 = mat.Kylmasilta.Osuus / mat.Kylmasilta.Aine.GetR();
                    RppT += 1 / (f1_R1 + f2_R2);
                }
                else
                {
                    RppT += mat.Materiaali.GetR();
                }
            }
            RppT += Rse; // ulkopinta
            Debug.WriteLine($"[ERITE] Alalikiarvo R\"T: {RppT} m2K/W");

            var ylaAlaKarvo = (ylalikiarvo_RT + RppT) / 2;
            var korjaamaton_U = 1 / ylaAlaKarvo;
            var mek_kiinn = 0d;
            var eristeen_ilmaraot = 0d;
            var korjattu_U = korjaamaton_U + mek_kiinn + eristeen_ilmaraot;
            return korjattu_U;
        }
    }

    public class MateriaaliKerros
    {
        public Kylmasilta Kylmasilta { get; set; }
        public Materiaali Materiaali { get; set; }
        //public double GetRT()
        //{
        //    if (null == Kylmasilta) return Materiaali?.GetR() ?? 0d;
        //    // likiarvot
        //    var paaOsuus = 1 - Kylmasilta.Osuus;
        //    var RTa = 
        //}
    }

    public class Kylmasilta
    {
        private double _osuus;
        public Materiaali Aine { get; set; }
        public double Osuus {
            get {
                if (_osuus >= 0 && _osuus <= 1) return _osuus;
                return 0;
            }
            
            set {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("Anna nollan ja ykkosen valilta");
                _osuus = value;
            }
        }
    }
}
