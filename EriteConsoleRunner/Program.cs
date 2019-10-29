using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using EriteLib;
using Newtonsoft.Json;
using Lambda = EriteLib.LampoLaskut.Lbd;

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
            Console.WriteLine($"E-luku: {test.LaskeELuku()} kWh_E/(m2 a)");
            Console.WriteLine();


            /*
            Console.WriteLine($"Maanvaraisen laatan johtumishavio: {test.MaanvaraisenLaatanJohtumishavio(1)} kWh/a");
            Console.WriteLine($"Vuotoilman lammitysenergia: {test.VuotoilmanLammitysenergiaPerVuosi()} kWh");
            Console.WriteLine($"e IV Nettotarve: {test.IVBrutto(1)} kWh");
            //Console.WriteLine($"e KV Nettotarve: {test.KayttoVedenVakioituKaytto()} kWh/v");
            Console.WriteLine($"e KV Nettotarve: {test.LKVTarve(1)} kWh");
            Console.WriteLine($"e IV sahkoenergia: {test.Kohta5LVIPumputSahkontarve(1)} kWh");
            Console.WriteLine($"e muu sahkoenergia: {test.ValaistusJaKulutussahko(1)} kWh");
            Console.WriteLine($"ihmis liha energia: {test.LampokuormaHenkiloista(1)} kWh");
            Console.WriteLine($"Ikkunoiden lampokuorma: {test.Kohta6IkkunoidenKauttaTulevaSateilyEnergia(1)} kWh");
            Console.WriteLine($"Lammitys tarve netto: {test.Kohta7LampokuormienHyodyntaminen(1)} kWh");
            Console.WriteLine($"Tulisija ja ILP: {test.Kohta8VaraavaTulisijaJaILPPerVuosi()} kWh");
            Console.WriteLine($"Lammitysjarjestelman energiankulutus: {test.Kohta9LammitysjarjestelmanEnergiankulutus(1)} kWh");
            */

            // testaa uu-arvoja

            // Kuparikatontie alakerran seina
            var kerrosRakenne = new KerrosRakenne { Name = "US1" };
            kerrosRakenne.LisaaKerros(Lambda.PuukuitulevyHuokoinen, 0.013); // haltex
            kerrosRakenne.LisaaKerros(Lambda.Puu, 0.022); // vaakalaudoitus
            kerrosRakenne.LisaaKerros(Lambda.Sahanpuru, 0.10, Lambda.Puu, 0.083); // sahanpuru + puu
            kerrosRakenne.LisaaKerros(Lambda.Puu, 0.022); // vinolaudoitus
            kerrosRakenne.LisaaKerros("Ilmarako", 0.04/0.130, 0.04); // ilmarako (R annettu 0.130)
            kerrosRakenne.LisaaKerros(Lambda.Tiili, 0.085); // tiili
            Console.WriteLine(kerrosRakenne.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne2 = new KerrosRakenne { Name = "US2 (vintin paatyseina)" };
            kerrosRakenne2.LisaaKerros(Lambda.PuukuitulevyHuokoinen, 0.013); // haltex
            kerrosRakenne2.LisaaKerros(Lambda.Puu, 0.022); // vaakalaudoitus
            kerrosRakenne2.LisaaKerros(Lambda.Mineraalivilla, 0.10, Lambda.Puu, 0.083); // sahanpuru + puu
            kerrosRakenne2.LisaaKerros(Lambda.Puu, 0.022); // vinolaudoitus
            kerrosRakenne2.LisaaKerros("Ilmarako", 0.04 / 0.130, 0.04); // ilmarako (R annettu 0.130)
            kerrosRakenne2.LisaaKerros(Lambda.Tiili, 0.085); // tiili
            Console.WriteLine(kerrosRakenne2.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne3 = new KerrosRakenne { Name = "US3 (ullakon vastainen)" };
            kerrosRakenne3.LisaaKerros(Lambda.PuukuitulevyHuokoinen, 0.013); // haltex
            kerrosRakenne3.LisaaKerros(Lambda.Puu, 0.022); // vaakalaudoitus
            kerrosRakenne3.LisaaKerros(Lambda.Mineraalivilla, 0.10, Lambda.Puu, 0.083); // sahanpuru + puu
            kerrosRakenne3.LisaaKerros(Lambda.Puu, 0.022); // vinolaudoitus
            kerrosRakenne3.LisaaKerros(Lambda.PuukuitulevyHuokoinen, 0.013); // haltex
            Console.WriteLine(kerrosRakenne3.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne4 = new KerrosRakenne { Name = "US4 (perusmuuri)" };
            kerrosRakenne4.LisaaKerros(Lambda.LaastiKalkkisementti, 0.025); // rappaus
            kerrosRakenne4.LisaaKerros("Kenno kevytsoraharkko", 0.15, 0.300); // ilmaeristetty kennoharkko
            kerrosRakenne4.LisaaKerros(Lambda.LaastiKalkkisementti, 0.025); // rappaus
            Console.WriteLine(kerrosRakenne4.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne5 = new KerrosRakenne { Name = "AP1" };
            kerrosRakenne5.LisaaKerros(Lambda.Betoni, 0.080); // lattialaatta
            kerrosRakenne5.LisaaKerros(Lambda.EPS, 0.150); // eriste
            Console.WriteLine(kerrosRakenne5.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne6 = new KerrosRakenne { Name = "AP2 (pesutilat)" };
            kerrosRakenne6.LisaaKerros(Lambda.Laatat, 0.015);
            kerrosRakenne6.LisaaKerros(Lambda.Betoni, 0.080); // lattialaatta
            Console.WriteLine(kerrosRakenne6.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne7 = new KerrosRakenne { Name = "YP1 (vinot osuudet)" };
            kerrosRakenne7.LisaaKerros(Lambda.Lastulevy, 0.012); // lastulevy / paneeli
            kerrosRakenne7.LisaaKerros(Lambda.Mineraalivilla, 0.125, Lambda.Puu, 0.083); // sahanpuru + puu
            Console.WriteLine(kerrosRakenne7.Rapsaa_U());
            Console.WriteLine();

            // Kuparikatontie
            var kerrosRakenne8 = new KerrosRakenne { Name = "YP2 (ylakolmio)" };
            kerrosRakenne8.LisaaKerros(Lambda.Lastulevy, 0.012); // lastulevy / paneeli
            kerrosRakenne8.LisaaKerros(Lambda.Mineraalivilla, 0.30, Lambda.Puu, 0.083); // sahanpuru + puu
            Console.WriteLine(kerrosRakenne8.Rapsaa_U());
            Console.WriteLine();

            var mabReader = new EriteLib.MabReader();
            var byteArray = new byte[] { 0x05, 0x2B, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0xAC, 0x08, 0x00, 0x00, 0x25, 0x00, 0x07, 0x00, 0x42, 0x65, 0x74, 0x6F, 0x6E, 0x69, 0x00 };
            mabReader.TryDecode(byteArray);
        }
    }
}
