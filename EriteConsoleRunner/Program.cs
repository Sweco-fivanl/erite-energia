using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using EriteLib;
using Newtonsoft.Json;

namespace EriteConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new EriteLib.EriteLaskuri();
            // deserialize JSON directly from a file
            TaloAttributes json;
            using (StreamReader file = File.OpenText(@"..\..\test_data\harjoitustalo.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                json = (TaloAttributes)serializer.Deserialize(file, typeof(TaloAttributes));
            }
            //var json = serializer.Deserialize<TaloAttributes>(File.ReadAllText(@"..\..\test_data\harjoitustalo.json"));
            //JObject o1 = JObject.Parse
            test.SetConfig(json);
            Console.WriteLine($"test: {test.LaskeJotain()}");

            Console.WriteLine($"Maanvaraisen laatan johtumishavio: {test.MaanvaraisenLaatanJohtumishavio()} kWh/a");
            Console.WriteLine($"Vuotoilman lammitysenergia: {test.VuotoilmanLammitysenergia()} kWh");
            Console.WriteLine($"e IV Nettotarve: {test.IVBrutto()} kWh");
            //Console.WriteLine($"e KV Nettotarve: {test.KayttoVedenVakioituKaytto()} kWh/v");
            Console.WriteLine($"e KV Nettotarve: {test.LKVTarve()} kWh");
            Console.WriteLine($"e IV sahkoenergia: {test.Kohta5LVIPumputSahkontarve()} kWh");
            Console.WriteLine($"e muu sahkoenergia: {test.ValaistusJaKulutussahko()} kWh");
            Console.WriteLine($"ihmis liha energia: {test.LampokuormaHenkiloista()} kWh");
            Console.WriteLine($"Ikkunoiden lampokuorma: {test.Kohta6IkkunoidenKauttaTulevaSateilyEnergia()} kWh");
            Console.WriteLine($"Lammitys tarve netto: {test.Kohta7LampokuormienHyodyntaminen()} kWh");
            Console.WriteLine($"Tulisija ja ILP: {test.Kohta8VaraavaTulisijaJaILPPerVuosi()} kWh");
            Console.WriteLine($"Lammitysjarjestelman energiankulutus: {test.Kohta9LammitysjarjestelmanEnergiankulutus()} kWh");


            // testaa uu-arvoja
            var kerrosRakenne = new KerrosRakenne();
            kerrosRakenne.LisaaKerros(0.21, 0.013); // EK
            kerrosRakenne.LisaaKerros(0.033, 0.15, 0.12, 0.083); // villa + puu
            kerrosRakenne.LisaaKerros(0.031, 0.05); // TS
            kerrosRakenne.LisaaKerros(0.04/0.130, 0.04); // ilmarako (R annettu 0.130)
            kerrosRakenne.LisaaKerros(0.5, 0.085); // tiili
            Console.WriteLine($"Uc: {String.Format("{0:0.##}", kerrosRakenne.Laske_U())} W/m2K");

            var mabReader = new EriteLib.MabReader();
            var byteArray = new byte[] { 0x05, 0x2B, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0xAC, 0x08, 0x00, 0x00, 0x25, 0x00, 0x07, 0x00, 0x42, 0x65, 0x74, 0x6F, 0x6E, 0x69, 0x00 };
            mabReader.TryDecode(byteArray);
        }
    }
}
