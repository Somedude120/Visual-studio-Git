using System;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Substraction(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ze Calculator, yes yes: ");
        }
    }
}
