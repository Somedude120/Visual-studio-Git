using System;
using System.Diagnostics;

namespace Calculator_Framework
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

            if (a < 0)
                throw new System.ArithmeticException();

            if (b < 0)
                throw new System.ArithmeticException();

            return Math.Pow(a, b);
        }

        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
                throw new System.DivideByZeroException();
            return dividend / divisor;
        }

        //Så vi skal lave lidt get set syntaks, det er en anden metode at lave get og set funktionen
        public double Accumulator //Lav property 
        { get; set; } //Bliver set som get{return Accumulator;} og set {Accumulator = værdi;}

        public void Clear()
        {
            this.Accumulator = 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ze Calculator, yes yes: ");

            double a = 5, b = 1, c = 10, d = 0;
            
            var result = new Calculator();
            double sum = 0;
            try
            {
                sum = result.Divide(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result.Divide(a,b));
                result.Accumulator = sum; //Giver summen til accumulatoren. Kinda useless
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted to divide by zero.");
            }
            //Ved at jeg kan sætte det i jeres system, afprøver bare min egen exception skabelon.
            try
            {
                sum = result.Power(c, d);
                result.Accumulator = sum; //Igen giver summen, så den virker
                Console.WriteLine($"Power of {c} in {d} = {sum}");
                
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Attempted to do Pow function with negative number.");
            }

            Console.WriteLine($"Accumulation last sum: {result.Accumulator}"); //Den giver den sidste sum

            Console.ReadKey();
        }
    }
}
