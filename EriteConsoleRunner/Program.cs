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

            var mabReader = new EriteLib.MabReader();
            var byteArray = new byte[] { 0x05, 0x2B, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0xAC, 0x08, 0x00, 0x00, 0x25, 0x00, 0x07, 0x00, 0x42, 0x65, 0x74, 0x6F, 0x6E, 0x69, 0x00 };
            mabReader.TryDecode(byteArray);
        }
    }
}
