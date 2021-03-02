using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EriteLib
{
    public class Materiaali
    {
        public Materiaali() { }

        public Materiaali(string name, double lambda)
        {
            Name = name;
            Lambda = lambda;
        }

        public double Lambda { get; set; }
        public string Name { get; set; }
        public double GetR(double thickness)
        {
            if (0 == Lambda) return 0;
            return thickness / Lambda;
        }
    }

    public class KerrosRakenne
    {
        public string Name { get; set; }
        public double Rsi { get; set; } = 0.130;
        public double Rse { get; set; } = 0.040;
        public double ReportArea { get; set; }
        private List<MateriaaliKerros> _kerrokset;
        public List<MateriaaliKerros> Kerrokset
        {
            get
            {
                if (null == _kerrokset) _kerrokset = new List<MateriaaliKerros>();
                return _kerrokset;
            }
        }


        public void LisaaKerros(Materiaali materiaali, double d)
        {
            Kerrokset.Add(new MateriaaliKerros
            {
               Materiaali = materiaali, 
               Thickness = d
            });
        }

        public void LisaaKerros(string name, double lambda, double d)
        {
            Kerrokset.Add(new MateriaaliKerros
            {
                Materiaali = new Materiaali
                {
                    Name = name,
                    Lambda = lambda,
                },
                Thickness = d
            });
        }

        public void LisaaKerros(Materiaali materiaali, double paksuus, Materiaali kylmasilta, double osuus)
        {
            Kerrokset.Add(new MateriaaliKerros
            {
                Materiaali = materiaali,
                Kylmasilta = new Kylmasilta
                {
                    Aine = new Materiaali { Lambda = kylmasilta.Lambda },
                    Osuus = osuus
                },
                Thickness = paksuus
            });
        }

        public void LisaaKerros(double lambda, double d, double kylmaLambda, double osuus)
        {
            Kerrokset.Add(new MateriaaliKerros
            {
                Materiaali = new Materiaali { Lambda = lambda },
                Kylmasilta = new Kylmasilta
                {
                    Aine = new Materiaali { Lambda = kylmaLambda },
                    Osuus = osuus
                },
                Thickness = d
            });
        }

        private static void KerrosTiedot(StringBuilder rapsaaja, int leveys, string teksti, double arvo, MateriaaliKerros kerros = null)
        {
            var value = String.Format("{0,5}", arvo);
            value = value.Length <= 5 ? value : value.Substring(0, 5);
            //int paksuus = kerros != null ? 
            var col = "{0,-" + leveys + "}";
            rapsaaja.Append(String.Format(col, teksti));
            if(null != kerros)
            {
                rapsaaja
                    .Append(" : ")
                    .Append(String.Format("{0,5}", (int)(kerros.Thickness * 1000)))
                    .Append(" mm");
            }
            else
            {
                rapsaaja.Append(new String(' ', 11));
            }
            rapsaaja
                .Append(" : ")
                .Append(value)
                .Append(" W/mK");
            if (null != kerros && null != kerros.Kylmasilta)
            {
                rapsaaja.Append(" (kylmasilta)");
            }
            rapsaaja.AppendLine();
        }

        public string Rapsaa_U()
        {
            int maxLen = int.MinValue;
            foreach (var mat in Kerrokset)
            {
                if (mat.Materiaali.Name.Length > maxLen) maxLen = mat.Materiaali.Name.Length;
            }
            maxLen = Math.Max(20, maxLen);

            var rapsa = new StringBuilder();
            rapsa.Append(Name ?? $"<noname>");
            if (ReportArea > 0)
            {
               rapsa.Append($" [pinta-ala: {ReportArea} m2]");
            }
            rapsa.AppendLine(" :");
            KerrosTiedot(rapsa, maxLen, "Pintavastus(i)", Rsi);
            foreach (var mat in Kerrokset)
            {
                KerrosTiedot(rapsa, maxLen, mat.Materiaali.Name, mat.Materiaali.Lambda, mat);
            }
            KerrosTiedot(rapsa, maxLen, "Pintavastus(e)", Rse);
            rapsa.AppendLine($"Uc: {String.Format("{0:0.##}", Laske_U())} W/m2K");
            return rapsa.ToString();
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
                RTa += mat.Materiaali.GetR(mat.Thickness);
                if (mat.Kylmasilta != null)
                {
                    if (kylmasiltoja) throw new Exception("Vain yksi kylmasilta tuettu");
                    kylmasiltoja = true;
                    RTb += mat.Kylmasilta.Aine.GetR(mat.Thickness);
                    bOsuus = mat.Kylmasilta.Osuus;
                }
                else
                {
                    RTb += mat.Materiaali.GetR(mat.Thickness);
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
                    var f1_R1 = (1 - mat.Kylmasilta.Osuus) / mat.Materiaali.GetR(mat.Thickness);
                    var f2_R2 = mat.Kylmasilta.Osuus / mat.Kylmasilta.Aine.GetR(mat.Thickness);
                    RppT += 1 / (f1_R1 + f2_R2);
                }
                else
                {
                    RppT += mat.Materiaali.GetR(mat.Thickness);
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
        public double Thickness { get; set; }
        public double ReportArea { get; set; }
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
