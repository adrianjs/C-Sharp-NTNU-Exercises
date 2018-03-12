using System;

namespace Ex3_Task2
{
    public class Person : IComparable, IEquatable<Person>
    {
        public String Navn { get; private set; }
        public int Formue { get; private set; }

        public Person(String navn, int formue)
        {
            Navn = navn;
            Formue = formue;
        }

        public override string ToString()
        {
            return Navn + " " + Formue.ToString() + "\n";
        }

        public int CompareTo(object obj)
        {
            if (obj is Person)
            {
                Person p = (Person) obj;
                return Formue.CompareTo(p.Formue);
            }

            return 2;
        }
        
        public bool Equals(Person other)
        {
            return Formue == other.Formue;
        }

        
    }
}