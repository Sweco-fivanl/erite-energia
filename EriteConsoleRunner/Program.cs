using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EriteLib;

namespace EriteConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new EriteLib.EriteLaskuri();
            Console.WriteLine($"test: {test.LaskeJotain()}");

            Console.WriteLine($"Maanvaraisen laatan johtumishavio: {test.MaanvaraisenLaatanJohtumishavio()}");
            Console.WriteLine($"Vuotoilman lammitysenergia: {test.VuotoilmanLammitysenergia()} kWh");

            Console.WriteLine($"e luku whatnot: {test.UusiFunktio()} kWh");
        }
    }
}
