using System;
using System.IO.Pipes;

namespace CSharp_Kalkulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Boolean exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to C# Simple Calculator!");
                Console.WriteLine("You will type in two numbers, and the operator to apply to them");
                Console.WriteLine("then receive the solution.");
                Console.WriteLine("Please enter first number: ");
                string firstNum = Console.ReadLine();
                int firstNumInt = Convert.ToInt32(firstNum);
                Console.WriteLine("Please enter second number: ");
                string secondNum = Console.ReadLine();
                int secondNumInt = Convert.ToInt32(secondNum);
                Console.WriteLine("Please enter operator (+ or -): ");
                string operatorString = Console.ReadLine();
                char operatorChar = Convert.ToChar(operatorString);
                Console.WriteLine(" ");
                switch (operatorChar)
                {
                    case '+':
                        Console.WriteLine($"The solution is {firstNumInt} {operatorChar} {secondNumInt} = {firstNumInt + secondNumInt}");
                        break;
                    case '-':
                        Console.WriteLine($"The solution is {firstNumInt} {operatorChar} {secondNumInt} = {firstNumInt - secondNumInt}");
                        break;
                    default:
                        Console.WriteLine("Not a recognized operator. Please enter either + or -.");
                        operatorString = Console.ReadLine();
                        operatorChar = Convert.ToChar(operatorString);
                        break;
                }
                Console.WriteLine("Want to do another equation? (y/n)");
                string answerString = Console.ReadLine();
                char answer = Convert.ToChar(answerString);
                if (answer != 'y' || answer != 'n' || answer != 'Y' || answer != 'N')
                {
                    Console.WriteLine("Not a recognized answer. Please enter either y or n.");
                    answerString = Console.ReadLine();
                    answer = Convert.ToChar(answerString);
                }

                if (answer != 'n') continue;
                exit = true;
                break;
            }
        }
    }
}