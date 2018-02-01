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

        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
                throw new System.DivideByZeroException();
            return dividend / divisor;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ze Calculator, yes yes: ");

            double a =10, b=0;
            var result = new Calculator();

            try
            {
                var sum = result.Divide(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted to divide by zero.");
            }

            Console.ReadKey();
        }
    }
}
