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
        { get; private set; } //Bliver set som get{return Accumulator;} og set {Accumulator = værdi;}
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ze Calculator, yes yes: ");

            double a = 10, b = 0, c = 10, d = -2;
            
            var result = new Calculator();

            string number = Console.ReadLine(); //ReadLine er strings... den skal laves om til double
            double newNumber = Convert.ToDouble(number); //Lav numret om til en double
            double f = result.Accumulator = newNumber; //Accumulator modtager et nyt nummer

            Console.WriteLine($"{f}"); //Et output af accumulatoreren
            
            var summing = result.Add(f, f); //Laver en sum med den accumulatoreren virker
            
            Console.WriteLine($"{f} + {f} = {summing}"); //Se det virker!

            try
            {
                var sum = result.Divide(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted to divide by zero.");
            }
            //Ved at jeg kan sætte det i jeres system, afprøver bare min egen exception skabelon.
            try
            {
                var sum = result.Power(c, d);
                Console.WriteLine($"Power of {c} in {d} = {sum}");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Attempted to do Pow function with negative number.");
            }

            Console.ReadKey();
        }
    }
}
