using System;
using NUnit.Framework;
using CalculatorProject;

namespace Calculator.Unit.Test
{
    public class CalculatorUnitTest
    {
        private CalculatorProject.Calculator uut;
        [SetUp]
        public void Setup()
        {
            uut = new CalculatorProject.Calculator();
        }

        #region AdditionTest
        [Test]
        public void Add_TwoPlusTwo_AssertFour()
        {
            double result = uut.Add(2.0, 2.0);
            Assert.That(result, Is.EqualTo(4).Within(0.0001));
        }

        [Test]
        public void Add_TwoDecimals_AssertTrue()
        {
            double result = uut.Add(2.3, 4.1);
            Assert.That(result, Is.EqualTo(6.4).Within(0.0001));
        }
        #endregion

        #region SubtractionTest
        [Test]
        public void Subtract_SmallFromBig_AssertResultCorrect()
        {
            double result = uut.Subtract(4.3, 3.7);
            Assert.That(result, Is.EqualTo(0.6).Within(0.0001));
        }

        [Test]
        public void Subtract_NegativeFromPositive_AssertResultCorrect()
        {
            double result = uut.Subtract(4.3, -3.7);
            Assert.That(result, Is.EqualTo(8).Within(0.0001));
        }

        [Test]
        public void Subtract_PositiveFromNegative_AssertResultCorrect()
        {
            double result = uut.Subtract(-4.3, 3.7);
            Assert.That(result,Is.EqualTo(-8.0).Within(0.0001));
        }
#endregion

        #region PowerTest
        [TestCase(2,4,16)]
        [TestCase(-2, 4, 16)]
        [TestCase(-2, 3, -8)]
        [TestCase(2, -4, 0.0625)]
        [TestCase(-2, -4, 0.0625)]
        public void Power_PositiveNegative_ReturnsExpected(double x, double exp, double res)
        {
            double result = uut.Power(x, exp);
            Assert.That(result, Is.EqualTo(res).Within(0.0001));
        }

        [TestCase(0, 4)]
        [TestCase(0, 12)]
        [TestCase(0, 0.1)]
        public void Power_ZeroXPositiveExp_ReturnsZero(double x, double exp)
        {
            double result = uut.Power(x, exp);
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Power_ZeroX_NegativeExp_Error()
        {
            Assert.Throws<DivideByZeroException>(() => uut.Power(0,-4),"Divided by zero");
        }

        [TestCase(0,0)]
        [TestCase(2, 0)]
        [TestCase(-2, 0)]
        [TestCase(24.3, 0)]
        [TestCase(-0.14, 0)]
        public void Power_ExpIs0_ReturnsOne(double x, double exp)
        {
            double result = uut.Power(x, exp);
            Assert.That(result, Is.EqualTo(1));
        }

        #endregion

        #region MultiplyTest
        [Test]
        public void Multiply_PositiveWithPositive_AssertValueCorrect()
        {
            double result = uut.Multiply(4, 5.5);
            Assert.That(result, Is.EqualTo(22.0).Within(0.00001));
        }

        [Test]
        public void Multiply_PositiveWithNegative_AssertValueCorrect()
        {
            double result = uut.Multiply(2.5, -6);
            Assert.That(result, Is.EqualTo(-15.0).Within(0.00001));
        }

        [Test]
        public void Multiply_NegativeWithNegative_AssertValueCorrect()
        {
            double result = uut.Multiply(-30, -1.2);
            Assert.That(result, Is.EqualTo(36.0).Within(0.00001));
        }
        #endregion

        #region DivisionTest
        [Test]
        public void Divide_PositiveFromPositive_AssertResultCorrect()
        {
            double result = uut.Divide(9, 3);
            Assert.That(result, Is.EqualTo(3));
        }
#endregion

        #region AccumulatorTest

        [Test]
        public void Acc_RetrieveAfterAddition()
        {
            uut.Add(2.1, 2.3);
            Assert.That(uut.Accumulator, Is.EqualTo(4.4).Within(0.0001));
        }

        [Test]
        public void Acc_RetrieveAfterSubtraction()
        {
            uut.Subtract(15, 16.7);
            Assert.That(uut.Accumulator, Is.EqualTo(-1.7).Within(0.0001));
        }
        [Test]
        public void Acc_RetrieveAfterMultiplication()
        {
            uut.Multiply(-3, -2);
            Assert.That(uut.Accumulator, Is.EqualTo(6).Within(0.0001));
        }
        [Test]
        public void Acc_RetrieveAfterExponent()
        {
            uut.Power(2, 8);
            Assert.That(uut.Accumulator, Is.EqualTo(256).Within(0.0001));
        }
        [Test]
        public void Acc_RetrieveAfterDivision()
        {
            uut.Divide(5, 2);
            Assert.That(uut.Accumulator, Is.EqualTo(2.5).Within(0.0001));
        }

        [Test]
        public void Acc_StartsAtZero()
        {
            Assert.That(uut.Accumulator,Is.Zero);
        }

        [Test]
        public void Acc_ClearAfterAddition()
        {
            uut.Add(5, 4);
            uut.Clear();
            Assert.That(uut.Accumulator, Is.Zero);
        }
        #endregion
    }
}
