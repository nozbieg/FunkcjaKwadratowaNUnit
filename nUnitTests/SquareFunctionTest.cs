using FunkcjaKwadratowaWithNUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitTests
{
    [TestFixture]
    public class SquareFunctionTest
    {
        private SquareFunction squareFunction;

        [SetUp]
        public void SetUp()
        {
            squareFunction = new SquareFunction();
        }

        [Test]
        public void SquareFunction_IsNull_Test()
        {
            Assert.IsNotNull(squareFunction, "Object SquareFunction should exist");
        }
        [Test]
        public void SquareFunction_InitParameter_Test()
        {

            Assert.AreEqual(squareFunction.ParameterA, 0, "Parameter A should be equal 0");
            Assert.AreEqual(squareFunction.ParameterB, 0, "Parameter B should be equal 0");
            Assert.AreEqual(squareFunction.ParameterC, 0, "Parameter C should be equal 0");
        }
        [Test]
        [TestCase(1, 2, 3)]
        public void SquareFunction_SettingParameter_Test(double parameterA, double parameterB, double parameterC)
        {
            squareFunction.ParameterA = parameterA;
            squareFunction.ParameterB = parameterB;
            squareFunction.ParameterC = parameterC;

            Assert.AreEqual(squareFunction.ParameterA, parameterA, $"Parameter A should be equal {parameterA}");
            Assert.AreEqual(squareFunction.ParameterB, parameterB, $"Parameter B should be equal {parameterB}");
            Assert.AreEqual(squareFunction.ParameterC, parameterC, $"Parameter C should be equal {parameterC}");
        }

        [Test]
        public void CalculateDelta_IsNotNull_Test()
        {
            var delta = squareFunction.CalculateDelta();
            Assert.IsNotNull(delta, "Delta cannot be null");
        }

        [Test]
        [TestCase(2, 3, 4, -23)]
        [TestCase(2, 8, 1, 56)]
        [TestCase(2, 4, 2, 0)]
        public void CalculateDelta_Equal_Test(double parameterA, double parameterB, double parameterC, double result)
        {
            squareFunction.ParameterA = parameterA;
            squareFunction.ParameterB = parameterB;
            squareFunction.ParameterC = parameterC;

            var delta = squareFunction.CalculateDelta();

            Assert.AreEqual(delta, result, $"For A:{parameterA},B:{parameterB},C:{parameterC} delta should be equal to {result} ");
        }

        [Test]
        [TestCase(2, 3, 4, -23)]
        [TestCase(2, 8, 1, 56)]
        [TestCase(2, 4, 2, 0)]
        public void CalculateDeltaOverride1_Equal_Test(double parameterA, double parameterB, double parameterC, double result)
        {
            var delta = squareFunction.CalculateDelta(parameterA, parameterB, parameterC);

            Assert.AreEqual(delta, result, $"For A:{parameterA},B:{parameterB},C:{parameterC} delta should be equal to {result} ");
        }


    }
}
