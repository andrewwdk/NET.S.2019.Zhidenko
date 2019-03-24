using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._2;

namespace NUnitTests
{
    [TestFixture]
    public class RootTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double Method_with_valid_data_returns_correct_result(double number, int root, double epsilon)
        {
            return Root.FindNthRoot(number, root, epsilon);
        }

        [TestCase(8, 15, -7)]
        [TestCase(8, 15, -0.6)]
        [TestCase(8, -15, 0.001)]
        public void Method_with_invalid_data_returns_ArgumentOutOfRangeExeption(double number, int root, double epsilon)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Root.FindNthRoot(number, root, epsilon));
        }
    }
}
