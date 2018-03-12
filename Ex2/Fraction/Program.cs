using System;

namespace Fraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fraction1 = new Fraction(8, 65);
            var fraction2 = new Fraction(123, 342);

            var productOfFractions = fraction1.MultiplyFraction(fraction2);
            Console.WriteLine("This is a program that multiplies fractions.");
            Console.WriteLine("The fractions have already been defined and multiplied.");
            Console.WriteLine("This is the result: ");
            Console.WriteLine(productOfFractions.ToString(productOfFractions));
        }
    }
}