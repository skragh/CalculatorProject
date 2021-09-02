using System;

namespace CalculatorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 2.5;
            double b = 3.6;
            Calculator calc = new Calculator();

            Console.WriteLine($"Testing calculator with values: a:{a}  b:{b}");
            //testing add
            Console.WriteLine("testing Add");
            Console.WriteLine($"a+b = {calc.Add(a,b)}");
            Console.WriteLine($"a+(-b) = {calc.Add(a, -b)}");


            //testing subtract

            Console.WriteLine("testing Subtract");
            Console.WriteLine($"a-b = {calc.Subtract(a, b)}");
            Console.WriteLine($"a-(-b) = {calc.Subtract(a, -b)}");

            //testing multiply

            Console.WriteLine("testing Multiply");
            Console.WriteLine($"a*b = {calc.Multiply(a, b)}");
            Console.WriteLine($"a*(-b) = {calc.Multiply(a, -b)}");

            //testing power
            Console.WriteLine("testing Power");
            Console.WriteLine($"a^b = {calc.Power(a, b)}");
            Console.WriteLine($"a^(-b) = {calc.Power(a, -b)}");
        }
    }
}
