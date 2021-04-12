using System;

namespace FunkcjaKwadratowaWithNUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Function 1:");
            var x = new SquareFunction();
            x.ParameterA = 2;
            x.ParameterB = 8;
            x.ParameterC = 1;
            Console.WriteLine(x.ToString());

            Console.WriteLine("Function 2:");
            var y = new SquareFunction();
            y.ParameterA = 2;
            y.ParameterB = 4;
            y.ParameterC = 2;
            Console.WriteLine(y.ToString());

            Console.WriteLine("Function 3:");
            var z = new SquareFunction();
            z.ParameterA = 2;
            z.ParameterB = 3;
            z.ParameterC = 4;
            Console.WriteLine(z.ToString());
        }
    }
}
