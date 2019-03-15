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

            Console.WriteLine($"e IV Nettotarve: {test.IVBrutto()} kWh");
            //Console.WriteLine($"e KV Nettotarve: {test.KayttoVedenVakioituKaytto()} kWh/v");
            Console.WriteLine($"e KV Nettotarve: {test.LKVTarve()} kWh");
            Console.WriteLine($"e IV sahkoenergia: {test.Kohta5LVIPumputSahkontarve()} kWh");
            Console.WriteLine($"e muu sahkoenergia: {test.ValaistusJaKulutussahko()} kWh");
            Console.WriteLine($"ihmis liha energia: {test.LampokuormaHenkiloista()} kWh");
            Console.WriteLine($"Ikkunoiden lampokuorma: {test.Kohta6IkkunoidenKauttaTulevaSateilyEnergia()} kWh");
            Console.WriteLine($"Lampokuormien hyodyntaminen: {test.Kohta7LampokuormienHyodyntaminen()} kWh");

            
        }
    }
}
