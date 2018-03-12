using System;

namespace Ex3_Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Formueliste_1 formueliste = new Formueliste_1();
                Person a = new Person("Mats", 1554877);
                Person b = new Person("Thomas", 114877);
                Person c = new Person("David", 554877);
                Person d = new Person("Ann-Julie", 15577);
                formueliste.RegistrerNyPerson(a);
                formueliste.RegistrerNyPerson(b);
                formueliste.RegistrerNyPerson(c);
                formueliste.RegistrerNyPerson(d);
                Console.WriteLine("Usortert liste:");
                Console.WriteLine(formueliste.ToString());
                Person rikest = formueliste.GetRikest();
                Console.WriteLine("Rikeste personen: " + rikest);
                Person[] sortert = formueliste.Sorter();
                Console.WriteLine("Sortert liste: ");
                foreach (Person p in sortert)
                {
                    Console.Write(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError: " + e.Message);
            }
            finally
            {
                Console.WriteLine("\nProgrammet avsluttes.");
            }
        }
    }
}