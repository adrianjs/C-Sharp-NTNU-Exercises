using System;

namespace Fraction
{
    public class Fraction
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int wholeNumber)
        {
            Numerator = wholeNumber;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(Fraction original)
        {
            Numerator = original.Numerator;
            Denominator = original.Denominator;
        }

        private double FractionValue(Fraction fraction)
        {
            var num = (Double)fraction.Numerator;
            var den = (Double)fraction.Denominator;
            return num / den;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }

            return a;
        }

        private Fraction lowestTerm(Fraction fraction)
        {
            var gcd = GCD(fraction.Numerator, fraction.Denominator);
            var newNumerator = fraction.Numerator / gcd;
            var newDenominator = fraction.Denominator / gcd;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction MultiplyFraction(Fraction otherFraction)
        {
            var newNumerator = Numerator * otherFraction.Numerator;
            var newDenominator = Denominator * otherFraction.Denominator;
            var newFraction = lowestTerm(new Fraction(newNumerator, newDenominator));
            return newFraction;
        }

        public string ToString(Fraction fraction)
        {
            return ($"{fraction.Numerator}/{fraction.Denominator} = {FractionValue(fraction)}");
        }
    }
}