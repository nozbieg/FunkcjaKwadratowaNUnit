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
                if (roots == null)
                {
                    roots = new List<SquareRoot>();
                    if (Delta > 0)
                    {
                        roots = CalculateRoots(roots, 2);
                    }
                    if (Delta == 0)
                    {
                        roots = CalculateRoots(roots, 1);
                    }
                    return roots;
                }
                return roots;
            }
        }
        IList<SquareRoot> CalculateRoots(IList<SquareRoot> roots, int rootCount)
        {
            if (rootCount == 2)
            {
                var resultRoot = CountRoot(true);
                roots.Add(resultRoot);
                resultRoot = CountRoot(false);
                roots.Add(resultRoot);
            }
            else if (rootCount == 1)
            {
                var resultRoot = CountRoot();
                roots.Add(resultRoot);
            }

            return roots;
        }

        public SquareRoot CountRoot()
        {
            var root = new SquareRoot();
            if (Delta == 0)
            {
                root.Root = -ParameterB / (2 * ParameterA);
            }
            else
            {
                throw new ArgumentException("This method is dedicated for one square functions. Delta should be equal to 0");
            }
            return root;
        }

        public SquareRoot CountRoot(bool operand)
        {
            var root = new SquareRoot();
            if (Delta != 0 && Delta > 0)
            {
                if (operand == true)
                {
                    root.Root = Math.Round((-ParameterB + Math.Sqrt(Delta)) / (2 * ParameterA), 2);
                }
                else
                {
                    root.Root = Math.Round((-ParameterB - Math.Sqrt(Delta)) / (2 * ParameterA), 2);
                }
            }
            else
            {
                throw new ArgumentException("This method is dedicated for two square functions. Delta should be above 0");

            }
            return root;
        }
        public double CalculateDelta()
        {
            return Math.Pow(ParameterB, 2) - 4 * ParameterA * ParameterC;
        }

        public double CalculateDelta(double parameterA, double parameterB, double parameterC)
        {
            return Math.Pow(parameterB, 2) - 4 * parameterA * parameterC;
        }


        public override string ToString()
        {
            var returnString = string.Empty;
            if (Delta >= 0)
            {
                returnString = "Function roots are:" + Environment.NewLine;
                var count = 1;
                foreach (var root in Roots)
                {
                    returnString += $"Root {count} = {root.Root}" + Environment.NewLine;
                    count++;
                }
            }
            else
            {
                returnString = "Delta is under 0. There are no roots for this function";
            }
            return returnString;
        }
    }
}
