using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkcjaKwadratowaWithNUnit
{
    public class SquareFunction
    {
        public SquareFunction()
        {
            ParameterA = 0;
            ParameterB = 0;
            ParameterC = 0;
        }

        double delta;
        IList<SquareRoot> roots;

        public double ParameterA { get; set; }
        public double ParameterB { get; set; }
        public double ParameterC { get; set; }

        public double Delta
        {
            get
            {
                delta = CalculateDelta();
                return delta;
            }
        }

        public IList<SquareRoot> Roots
        {
            get
            {
                if (roots.Count == 0 && roots == null)
                {
                    roots = new List<SquareRoot>();

                    return roots;
                }
                return null;

            }
        }
        public double CalculateDelta()
        {
            return Math.Pow(ParameterB, 2) - 4 * ParameterA * ParameterC;
        }

        public double CalculateDelta(double parameterA, double parameterB, double parameterC)
        {
            return Math.Pow(parameterB, 2) - 4 * parameterA * parameterC;
        }

    }
}
