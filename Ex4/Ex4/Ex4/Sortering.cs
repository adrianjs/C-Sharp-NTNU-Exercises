using System;

namespace Ex4
{
    public class Sortering
    {
        public delegate bool Sammenligner(Tribune a, Tribune b);

        public static void Sorter(Tribune[] tabell, Sammenligner sml)
        {
            Console.WriteLine("\t");
            for (int i = 0; i < tabell.Length; i++)
            {
                Console.WriteLine(tabell[i].VisNavn());
                if (i < tabell.Length - 1)
                {
                    Console.WriteLine(" | ");
                }
            }

            for (int i = 0; i < tabell.Length; i++)
            {
                for (int j = 0; j < tabell.Length - 1; j++)
                {
                    if (sml(tabell[j], tabell[j + 1]))
                    {
                        Bytt(tabell, j, j + 1);
                    }
                }

            }
            Console.WriteLine("\n -> Liste etter sortering: ");
            Console.WriteLine("\t");
            for (int i = 0; i < tabell.Length; i++)
            {
                Console.WriteLine(tabell[i].VisNavn());
                if (i < tabell.Length - 1)
                {
                    Console.WriteLine(" | ");
                }
            }

            Console.WriteLine();
        }

        private static void Bytt(Object[] tabell, int i, int j)
        {
            Object temp = tabell[i];
            tabell[i] = tabell[j];
            tabell[j] = temp;
        }

        private static bool SorteringEtterNavn(Tribune a, Tribune b)
        {
            bool temp = string.CompareOrdinal(a.ToString(), b.ToString()) > 0;
            return temp;
        }

        public void SorterTabellEtterNavn(Tribune[] t)
        {
            Console.WriteLine("Sortering etter tribunenavn: ");
            Console.WriteLine(" -> Listen før sortering: ");
            Sammenligner sml = SorteringEtterNavn;
            Sorter(t, sml);
        }

        private static bool SorteringEtterInntekt(Tribune a, Tribune b)
        {
            bool temp = a.SolgtFor() < b.SolgtFor();
            return temp;
        }

        public void SorterTabellEtterInntekt(Tribune[] t)
        {
            Console.WriteLine("Sortering etter inntekt: ");
            Console.WriteLine(" -> Liste før sortering: ");
            Sammenligner sml = SorteringEtterInntekt;
            Sorter(t, sml);

            Console.WriteLine("Bevis for korrekt sortering: \n\t");
            for (int i = 0; i < t.Length; i++)
            {
                Console.WriteLine(t[i].VisNavn() + ": " + t[i].SolgtFor() + ",-");
                if (i < t.Length - 1) {
                    Console.WriteLine(" | ");
                }
            }
        }
    }
}