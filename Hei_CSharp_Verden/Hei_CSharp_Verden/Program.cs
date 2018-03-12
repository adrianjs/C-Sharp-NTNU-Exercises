using System;

namespace Hei_CSharp_Verden
{
    class Program
    {
        static void Main(string[] args)
        {
            int tall1;
            int tall2;
            Console.Write("Skriv inn et heltall: ");
            String temp = Console.ReadLine();
            tall1 = Int32.Parse(temp);
            
            Console.Write("Skriv inn heltall nr 2: ");
            temp = Console.ReadLine();
            tall2 = Int32.Parse(temp);
            int sum = tall1 + tall2;
            Console.Write("Summen av de to tallene er: " + sum);
        }
    }
}