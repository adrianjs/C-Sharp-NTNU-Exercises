using System;
using System.Collections.Generic;

namespace Ex3_Task2
{
    public class Formueliste_1
    {
        public List<Person> personer;
        private int standard = 100;

        public Formueliste_1()
        {
            personer = new List<Person>(standard);
        }

        public Formueliste_1(int antall)
        {
            personer = new List<Person>(antall);
        }

        public Formueliste_1(List<Person> p)
        {
            personer = p;
        }

        public bool RegistrerNyPerson(Person p)
        {
            if (p == null)
            {
                throw new Exception("Ugyldig objekt!");
            }

            personer.Add(p);
            return true;
        }

        public override string ToString()
        {
            String temp = "";
            foreach (Person p in this.personer)
            {
                temp += p.ToString();
            }
            if (temp == "") {throw new Exception("Ingenting å vise!");}

            return temp;
        }

        public Person GetRikest()
        {
            Person rikest = new Person("", 0);
            foreach (Person p in personer)
            {
                if (p.Formue > rikest.Formue)
                {
                    rikest = p;
                }
            }
            return rikest;
        }

        public List<Person> Sorter()
        {
            List<Person> sortertListe = this.personer;
            sortertListe.Sort((a,b) => -1 * a.CompareTo(b));
            return sortertListe;
        }

        public void PrintSortert()
        {
            personer.Sort();
            foreach (Person p in personer)
            {
                Console.WriteLine(p);
            }
        }

        public void PrintUsortert()
        {
            foreach (Person p in personer)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}