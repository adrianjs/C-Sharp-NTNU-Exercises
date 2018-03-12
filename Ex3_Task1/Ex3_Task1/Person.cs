using System;

namespace Ex3_Task1
{
    public class Person
    {
        public String Navn { get; private set; }
        public int Formue { get; private set; }
        
        public Person(String navn, int formue)
        {
            Navn = navn;
            Formue = formue;
        }

        public override String ToString()
        {
            return Navn + " " + Formue.ToString() + "\n";
        }
    }
}