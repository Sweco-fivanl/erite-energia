using System;
using System.Collections.Generic;
using System.Text;

namespace EriteLib
{
    public class TaloAttributes
    {
        public double Area { get; set; }
        public double InTemp { get; set; }
        public Ventilation Ventilation { get; set; }
    }

    public class Ventilation
    {
        public int RunningHours { get; set; }
        public double Ulkoilmavirta { get; set; }
        public double? LTO_COP { get; set; }
        public double KorvausilmanLampo { get; set; }
    }
}
