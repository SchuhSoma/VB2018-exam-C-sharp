using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_VB2018
{
    class Program
    {
        static List<VB2018> VBList;
        static string VarosNev;
        static List<string> VarosList;
        static void Main(string[] args)
        {
            Feladat2Beolvasas(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat3StadionokSzama(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat4Legkevesebb(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat5Atlag(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat6KetNev(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat7Bekeres(); Console.WriteLine("\n-------------------------------------------------------\n");
            Feladat9();
            Console.ReadKey();
        }

        private static void Feladat9()
        {
            Console.WriteLine("9.Feladat: Hány különböző, városban volt VB mérkőzés");
            VarosList = new List<string>();
            foreach (var v in VBList)
            {
                if(!VarosList.Contains(v.Varos))
                {
                    VarosList.Add(v.Varos);
                }
            }
            Console.WriteLine("\tEnnyi különböző helyen volt VB mérkőzés: {0}",VarosList.Count);
        }

        private static void Feladat7Bekeres()
        {
            Console.WriteLine("7.Feladat: Felhasználótól város név bekérése");
            int VarosNevHossz = 0;
            do
            {
                Console.Write("\tKérem adja meg egy VB város nevét: ");
                VarosNev= Console.ReadLine().ToLower();
                VarosNevHossz = VarosNev.Length;
                if(VarosNevHossz>3)
                {
                    Console.WriteLine("\n-------------------------------------------------------\n");
                    Feladat8(); 
                }
            } while (VarosNevHossz < 3);
        }

        private static void Feladat8()
        {
            Console.WriteLine("8.Feladat: Volt ebben a városban VB mérkőzés");
            int db = 0;
            foreach (var v in VBList)
            {
                if(v.Varos.ToLower().Contains(VarosNev))
                { 
                    db++;
                }
            }
            if(db>0)
            {
                Console.WriteLine("\tAz adott városban, volt VB esemény");
            }
            else
            {
                Console.WriteLine("\tAz adott városban, NEM volt VB esemény");
            }
        }

        private static void Feladat6KetNev()
        {
            Console.WriteLine("6.Feladat: Határozza meg, hány stadionnak van két neve");
            int db = 0;
            foreach (var v in VBList)
            {
                if(v.Nev2.ToLower()=="n.a.")
                {
                    db++;
                }
            }
            Console.WriteLine("\tEnnyi helyszínnek van két neve a listában: {0}",VBList.Count-db);
        }

        private static void Feladat5Atlag()
        {
            Console.WriteLine("5.Feladat: Határozza meg átlagosan hány frőhely volt a stadionokban");
            double Osszeg = 0;
            double Atlag = 0;
            foreach (var v in VBList)
            {
                Osszeg += v.Ferohely;
                Atlag = Osszeg / VBList.Count;
            }
            Console.WriteLine("\tÁtlagosan ennyi férőhely volt a VB stadionjaiban: {0:0.0}",Atlag);
        }

        private static void Feladat4Legkevesebb()
        {
            Console.WriteLine("4.Feladat: határozza meg a legkevesebb férőhellyel rendelkező stadiont");
            int MinFerohely = int.MaxValue;
            string MinVaros= "cica";
            string MinNev1 = "Cica";
            string MinNev2 = "cica";
            foreach (var v in VBList)
            {
                if(MinFerohely>v.Ferohely)
                {
                    MinFerohely = v.Ferohely;
                    MinVaros = v.Varos;
                    MinNev1 = v.Nev1;
                    MinNev2 = v.Nev2;
                }
            }
            Console.WriteLine("\tLegkevesebb férőhely: {0}\n\tVáros: {1}\n\tStadion neve: {2}",MinFerohely, MinVaros, MinNev1);
        }

        private static void Feladat3StadionokSzama()
        {
            Console.WriteLine("3.Feladat: Hány stadionban játszottak VB mérközést");
            Console.WriteLine("\tVB mérközést ennyi stadionban játszottak: {0}",VBList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: Beolvasás");
            VBList = new List<VB2018>();
            int db = 0;
            var sr = new StreamReader(@"vb2018.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                VBList.Add(new VB2018(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás, beolvasott sorok száma: {0}",db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás, próbáld újra");
            }
        }
    }
}
