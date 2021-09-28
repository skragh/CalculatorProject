using System;
using NUnit.Framework;
using CalculatorProject;

namespace Calculator.Unit.Test
{
    class OverloadUnitTest
    {
        private CalculatorProject.Calculator uut;
        [SetUp]
        public void Setup()
        {
            uut = new CalculatorProject.Calculator();
        }

        //Tests start here
        [TestCase(2.4, 2.6, 5)]
        [TestCase(5,-2,3)]
        [TestCase(-6,3,-3)]
        [TestCase(9,9.89,18.89)]
        public void SeparateSingleAddition_ResultAddedTogether(double a, double b, double c)
        {
            double result = uut.Add(a);
            Assert.That(result, Is.EqualTo(a).Within(0.0001));
            result = uut.Add(b);
            Assert.That(result, Is.EqualTo(c).Within(0.0001));
        }

        [TestCase (5.5, 6.5, 12, 6, 18)]
        [TestCase (2, 3, 5, 3, 8)]
        [TestCase (4, -3, 1, -2, -1)]
        public void NormalAndOverloadAdditionCompatibilityTest_CompatibleAddition(double a, double b, double c, double d, double e)
        {
            double result = uut.Add(a, b);
            Assert.That(result, Is.EqualTo(c).Within(0.0001));
            result = uut.Add(d);
            Assert.That(result, Is.EqualTo(e).Within(0.0001));
        }
    }
}
