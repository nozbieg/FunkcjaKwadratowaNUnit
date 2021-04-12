using System;

namespace FunkcjaKwadratowaWithNUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var x = new SquareFunction();
            x.ParameterA = 2;
            x.ParameterB = 8;
            x.ParameterC = 1;

            Console.WriteLine($"Pierwiastek równiania to {x.ToString()}");
        }
    }
}
