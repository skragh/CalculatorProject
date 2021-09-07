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

        [Test]
        public void Add_TwoPlusTwo_AssertFour()
        {
            double result = uut.Add(2.0, 2.0);
            Assert.That(result, Is.EqualTo(4).Within(0.0001));
        }

        [Test]
        public void Add_TwoDecimals_AssertTrue()
        {
            double result = uut.Add(2.3 ,4.1);
            Assert.That(result, Is.EqualTo(6.4).Within(0.0001));
        }

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

        
        [Test]
        public void Multiply_PositiveAndPositive()
        {
            double result = uut.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20).Within(0.0001));
        }

        [Test]
        public void Multiply_PositiveAndNegative()
        {
            double result = uut.Multiply(4, -5);
            Assert.That(result, Is.EqualTo(-20).Within(0.0001));
        }


        [Test]
        public void Multiply_NegativeAndPositive()
        {
            double result = uut.Multiply(-4, 5);
            Assert.That(result, Is.EqualTo(-20).Within(0.0001));
        }


        [Test]
        public void Multiply_NegativeAndNegative()
        {
            double result = uut.Multiply(-4, -5);
            Assert.That(result, Is.EqualTo(20).Within(0.0001));
        }


        [Test]
        public void Power_PositiveX_PositiveExp()
        {
            double result = uut.Power(2, 4);
            Assert.That(result, Is.EqualTo(16).Within(0.0001));
        }
        
        [Test]
        public void Power_NegativeX_PositiveEvenExp()
        {
            double result = uut.Power(-2, 4);
            Assert.That(result, Is.EqualTo(16).Within(0.0001));
        }

        [Test]
        public void Power_NegativeX_PositiveUnevenExp()
        {
            double result = uut.Power(-2, 3);
            Assert.That(result, Is.EqualTo(-8).Within(0.0001));
        }


        [Test]
        public void Power_PositiveX_NegativeExp()
        {
            double result = uut.Power(2, -4);
            Assert.That(result, Is.EqualTo(0.0625).Within(0.0001));
        }

        [Test]
        public void Power_NegativeX_NegativeExp()
        {
            double result = uut.Power(-2, -4);
            Assert.That(result, Is.EqualTo(0.0625).Within(0.0001));
        }

        [Test]
        public void Power_ZeroX_PositiveExp_AssertZero()
        {
            double result = uut.Power(0, 4);
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Power_ZeroX_NegativeExp_AssertError()
        {
            Assert.Throws<DivideByZeroException>(() => uut.Power(0,-4),"Divided by zero");
        }

        [Test]
        public void Power_ZeroX_ZeroExp_AssertOne()
        {
            double result = uut.Power(0, 0);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Power_PositiveX_ZeroExp_AssertOne()
        {
            double result = uut.Power(2, 0);
            Assert.That(result, Is.EqualTo(1).Within(0.0001));
        }
        [Test]
        public void Power_NegativeX_ZeroExp_AssertOne()
        {
            double result = uut.Power(-2, 0);
            Assert.That(result, Is.EqualTo(1).Within(0.0001));
        }
        //Multiply
        [Test]
        public void Multiply_PositiveWithPositive_AssertValueCorrect()
        {
            double result = uut.Multiply(4, 5.5);
            Assert.That(result, Is.EqualTo(22.0).Within(0.00001));
        }

        public void Multiply_PositiveWithNegative_AssertValueCorrect()
        {
            double result = uut.Multiply(2.5, -6);
            Assert.That(result, Is.EqualTo(-22.0).Within(0.00001));
        }

        public void Multiply_NegativeWithNegative_AssertValueCorrect()
        {
            double result = uut.Multiply(-30, -1.2);
            Assert.That(result, Is.EqualTo(35.0).Within(0.00001));
        }

        //Power

        public void Power_PositiveWithPositive_AssertValueCorrect()
        {
            double result = uut.Power(5, 2);
            Assert.That(result, Is.EqualTo(25).Within(0.0001));
        }

        //divideTest
        [Test]
        public void Divide_PositiveFromPositive_AssertResultCorrect()
        {
            double result = uut.Divide(9, 3);
            Assert.That(result, Is.EqualTo(3));
        }

//Accumulator tests
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


    }
}
