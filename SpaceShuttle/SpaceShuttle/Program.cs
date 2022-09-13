using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    internal class Program
    {
        public struct Kuldetes
        {
            public string KuldetesKod;
            public string KilovesDatum;
            public string UrsikloNev;
            public int KintToltottNap;
            public int KintToltottOra;
            public string LandolasHely;
            public int Legenyseg;
        }

        static void Main(string[] args)
        {            
            Kuldetes kuldetes = new Kuldetes();
            List<Kuldetes> kuldetesek = new List<Kuldetes>();
            StreamReader sr = new StreamReader("kuldetesek.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] sordarabok = sor.Split(';');
                kuldetes.KuldetesKod = sordarabok[0];
                kuldetes.KilovesDatum = sordarabok[1];
                kuldetes.UrsikloNev = sordarabok[2];
                kuldetes.KintToltottNap = int.Parse(sordarabok[3]);
                kuldetes.KintToltottOra = int.Parse(sordarabok[4]);
                kuldetes.LandolasHely = sordarabok[5];
                kuldetes.Legenyseg = int.Parse(sordarabok[6]);
                kuldetesek.Add(kuldetes);
            }
            HarmadikFeladat(kuldetesek);
            NegyedikFeladat(kuldetesek);
            OtodikFeladat(kuldetesek);
            HatodikFeladat(kuldetesek);
            HetedikFeladat(kuldetesek);
            NyolcadikFeladat(kuldetesek);
            sr.Close();
            Console.ReadKey();
        }

        private static void HarmadikFeladat(List<Kuldetes> kuldetesek)
        {
            Console.WriteLine("3. feladat:\n\tÖsszesen {0} alkalommal indítottak űrhajót.", kuldetesek.Count);
        }

        private static void NegyedikFeladat(List<Kuldetes> kuldetesek)
        {
            int OsszUtas = 0;
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                OsszUtas += kuldetesek[i].Legenyseg;
            }
            Console.WriteLine("4. feladat:\n\t{0} utas indult az űrbe összesen.", OsszUtas);
        }

        private static void OtodikFeladat(List<Kuldetes> kuldetesek)
        {
            int Alkalom = 0;
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                if (kuldetesek[i].Legenyseg<5)
                {
                    Alkalom++;
                }
            }
            Console.WriteLine("5. feladat:\n\tÖsszesen {0} alkalommal küldtek kevesebb, mint 5 embert az űrbe.", Alkalom);
        }

        private static void HatodikFeladat(List<Kuldetes> kuldetesek)
        {
            int UtolsoLegenyseg = 0;
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                if (kuldetesek[i].UrsikloNev == "Columbia" && kuldetesek[i].LandolasHely == "nem landolt")
                {
                    UtolsoLegenyseg = kuldetesek[i].Legenyseg;
                }
            }
            Console.WriteLine("6. feladat:\n\t{0} asztronauta volt a Columbia fedélzetén annak utolsó útján.", UtolsoLegenyseg);
        }

        private static void HetedikFeladat(List<Kuldetes> kuldetesek)
        {
            int MaxOra = int.MinValue;
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                int OsszOra = kuldetesek[i].KintToltottNap * 24 + kuldetesek[i].KintToltottOra;
                if (OsszOra > MaxOra)
                {
                    MaxOra = OsszOra;
                }
            }
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                if (kuldetesek[i].KintToltottNap*24+kuldetesek[i].KintToltottOra == MaxOra)
                {
                    Console.WriteLine("7. feladat:\n\tA leghosszabb ideig a {0} volt az űrben a(z) {1} küldetés során.\n\tÖsszesen {2} órát volt távol a Földtől.", kuldetesek[i].UrsikloNev, kuldetesek[i].KuldetesKod, MaxOra);
                }
            }
        }

        private static void NyolcadikFeladat(List<Kuldetes> kuldetesek)
        {           
            Console.Write("8. feladat:\n\tÉvszám: ");
            int db = 0;   
            int Evszam = int.Parse(Console.ReadLine());
            for (int i = 0; i < kuldetesek.Count; i++)
            {
                string[] Datumdarabok = kuldetesek[i].KilovesDatum.Split('.');
                if (int.Parse(Datumdarabok[0]) == Evszam)
                {
                    db++;
                }
            }
            if (db == 0)
            {
                Console.WriteLine("\tEbben az évben nem indult küldetés.");
            }
            else
            {
                Console.WriteLine("\tEbben az évben {0} küldetés volt.", db);
            }
        }
    }
}
