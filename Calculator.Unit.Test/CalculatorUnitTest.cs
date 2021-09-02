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
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Add_TwoDecimals_AssertTrue()
        {
            double result = uut.Add(2.3 ,4.1);
            Assert.AreEqual(6.4,result,0.1);
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
            Assert.True(result==8.0);
        }

        [Test]
        public void Subtract_PositiveFromNegative_AssertResultCorrect()
        {
            double result = uut.Subtract(-4.3, 3.7);
            Assert.True(result==-8.0);
        }

        //dividorTest
        [Test]
        public void Divide_PositiveFromPositive_AssertResultCorrect()
        {
            double result = uut.Divide(9, 3);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}