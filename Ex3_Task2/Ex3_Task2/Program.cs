using System;
using System.Collections.Generic;

namespace Ex3_Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Person> personer = new List<Person>();
                personer.Add(new Person("Mats", 102030));
                personer.Add(new Person("Ann", 222030));
                personer.Add(new Person("Silje", 10230));

                Formueliste_1 formueListe = new Formueliste_1(personer);
                Console.WriteLine("Usortert: ");
                Console.WriteLine(formueListe.ToString());
                Console.WriteLine("Sortert: ");
                Formueliste_1 sortertListe = new Formueliste_1(formueListe.Sorter());
                Console.WriteLine(sortertListe.ToString());

                Console.WriteLine("\nRikeste person: " + sortertListe.GetRikest());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Programmet avsluttes.");
            }
        }
    }
}