using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuvar
{
    class Program
    {

        //1.feladat

        struct fuvarozas
        {
            public int taxiid;
            public string indulas;
            public int idotartam;
            public double tavolsag;
            public double viteldij;
            public double borravalo;
            public string fizetesmod;
        }

        //2.feladat

        static fuvarozas[] adatok = new fuvarozas[2000];
        struct fuvarozas2
        {
            public int taxiid;
            public string indulas;
            public int idotartam;
            public double tavolsag;
            public double viteldij;
            public double borravalo;
            public string fizetesmod;
        }
        static fuvarozas2[] adatok2 = new fuvarozas2[2000];
        static void Main(string[] args)
        {
            string[] fajlbol = File.ReadAllLines("fuvar.csv");
            int sorokszama = 0;
            int i, j;
            for (int k = 1; k < fajlbol.Count(); k++)
            {
                string[] egysordarabolva = fajlbol[k].Split(';');
                adatok[sorokszama].taxiid = Convert.ToInt32(egysordarabolva[0]);
                adatok[sorokszama].indulas = egysordarabolva[1];
                adatok[sorokszama].idotartam = Convert.ToInt32(egysordarabolva[2]);
                adatok[sorokszama].tavolsag = Convert.ToDouble(egysordarabolva[3]);
                adatok[sorokszama].viteldij = Convert.ToDouble(egysordarabolva[4]);
                adatok[sorokszama].borravalo = Convert.ToDouble(egysordarabolva[5]);
                adatok[sorokszama].fizetesmod = egysordarabolva[6];
                sorokszama++;
            }
            int fuvarokszama = sorokszama;

            //3.feladat

            Console.WriteLine("3. feladat: {0} fuvar", fuvarokszama);

            //4.feladat

            double osszesen = 0;
            int db = 0;
            for (i = 0; i < fuvarokszama; i++)
            {
                if (adatok[i].taxiid == 6185)
                {
                    osszesen += adatok[i].viteldij;
                    db++;
                }
            }
            Console.WriteLine("4. feladat: {0} fuvar alatt: {1} $", db, osszesen);


            //5.feladat

            int kulonbozoelemekszama = 0;
            string[] fizetesimodok = new string[100];
            int[] fizetesszam = new int[100];
            for (i = 0; i < fuvarokszama; i++)
            {
                j = 0;
                while ((j <= kulonbozoelemekszama) && (adatok[i].fizetesmod != fizetesimodok[j]))
                {
                    j++;
                }
                if (j > kulonbozoelemekszama)
                {
                    kulonbozoelemekszama++;
                    fizetesimodok[kulonbozoelemekszama] = adatok[i].fizetesmod;
                }

            }

            for (i = 0; i < fuvarokszama; i++)
            {
                for (int k = 1; k <= kulonbozoelemekszama; k++)

                {
                    if (fizetesimodok[k] == adatok[i].fizetesmod) fizetesszam[k]++;
                }

            }
            Console.WriteLine("5. feladat:");
            for (i = 1; i <= kulonbozoelemekszama; i++)
                Console.WriteLine("\t{0}: {1} fuvar ", fizetesimodok[i], fizetesszam[i]);


        }
    }
}