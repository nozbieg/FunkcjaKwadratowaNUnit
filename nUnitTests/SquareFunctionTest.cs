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
        [Test]
        public void CountRoot_Delta0_Equal_Test()
        {
            squareFunction.ParameterA = 2;
            squareFunction.ParameterB = 4;
            squareFunction.ParameterC = 2;

            Assert.DoesNotThrow(() => squareFunction.CountRoot());
            Assert.AreEqual(squareFunction.Delta, 0, "Delta should be equal to 0");
            Assert.AreEqual(squareFunction.Roots.Count, 1, "This function should have only one Root");
            Assert.AreEqual(squareFunction.Roots[0].Root, -1, $"The root value should be equal to -1");
        }
        [Test]
        [TestCase(2, 3, 4)]
        [TestCase(2, 8, 1)]
        public void CountRoot_Delta0_WrongDelta_Test(double parameterA, double parameterB, double parameterC)
        {
            squareFunction.ParameterA = parameterA;
            squareFunction.ParameterB = parameterB;
            squareFunction.ParameterC = parameterC;

            var ex = Assert.Throws<ArgumentException>(() => squareFunction.CountRoot());
            Assert.That(ex.Message, Is.EqualTo($"This method is dedicated for one square functions. Delta should be equal to 0"));
        }

        [Test]
        [TestCase(2, 3, 4)]
        [TestCase(2, 4, 2)]
        public void CountRoot_DeltaPositive_WrongDelta_Test(double parameterA, double parameterB, double parameterC)
        {
            squareFunction.ParameterA = parameterA;
            squareFunction.ParameterB = parameterB;
            squareFunction.ParameterC = parameterC;

            var ex = Assert.Throws<ArgumentException>(() => squareFunction.CountRoot(true));
            Assert.That(ex.Message, Is.EqualTo($"This method is dedicated for two square functions. Delta should be above 0"));
        }

        [Test]
        [TestCase(2, 8, 1, 56, -0.13, -3.87)]
        public void CountRoot_DeltaPositive_Equal_Test(double parameterA, double parameterB, double parameterC,
                                                       double resultDelta, double resultRoot1, double resultRoot2)
        {
            squareFunction.ParameterA = parameterA;
            squareFunction.ParameterB = parameterB;
            squareFunction.ParameterC = parameterC;

            Assert.DoesNotThrow(() => squareFunction.CountRoot(true));
            Assert.AreEqual(squareFunction.Delta, resultDelta, $"Delta should be equal to {resultDelta}");
            Assert.AreEqual(squareFunction.Roots.Count, 2, "This function should have two Root");
            Assert.AreEqual(squareFunction.Roots[0].Root, resultRoot1, $"The root value should be equal to {resultRoot1}");
            Assert.AreEqual(squareFunction.Roots[1].Root, resultRoot2, $"The root value should be equal to {resultRoot2}");
        }


    }
}
