using System;
using System.Runtime.InteropServices;

namespace Ex3_Task1
{
    public class Formueliste_1
    {
        private Person[] personer { get; set; }
        private int standard = 100;
        public int personTeller { get; set; }

        public Formueliste_1()
        {
            personer = new Person[standard];
            personTeller = 0;
        }

        public Formueliste_1(int antall)
        {
            personer = new Person[antall];
            personTeller = 0;
        }

        public Formueliste_1(Formueliste_1 formueListe)
        {
            personer = formueListe.personer;
            personTeller = 0;
        }

        public bool RegistrerNyPerson(Person p)
        {
            bool registrert = false;
            try
            {
                if (personTeller < personer.Length)
                {
                    personer[personTeller] = p;
                    registrert = true;
                    ++personTeller;
                }
                else
                {
                    throw new Exception("Tabellen er full!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return registrert;
        }

        public Person GetRikest()
        {
            Person temp = new Person("", 0);
            if (!ErTom())
            {
                for (int i = 0; i < personTeller; i++)
                {
                    if (personer[i].Formue > temp.Formue)
                    {
                        temp = personer[i];
                    }
                }
            }
            else
            {
                throw new Exception("Ingenting å vise!");
            }

            return temp;
        }

        public Person[] Sorter()
        {
            Person[] tempTabell = this.personer;
            Person temp = new Person("", 0);
            for (int i = 0; i < personTeller; i++)
            {
                for (int j = 0; j < personTeller - 1; j++)
                {
                    if (tempTabell[j].Formue < tempTabell[j + 1].Formue)
                    {
                        temp = tempTabell[j + 1];
                        tempTabell[j + 1] = tempTabell[j];
                        tempTabell[j] = temp;
                    }
                }
            }

            return tempTabell;
        }

        public override String ToString()
        {
            String temp = "";
            if (personTeller != 0)
            {
                foreach (Person p in personer)
                {
                    temp += p;
                }
            }

            return temp;
        }

        private bool ErTom()
        {
            return personTeller == 0;
        }

        public void visAntall()
        {
            Console.WriteLine(this.personTeller);
        }
    }
}