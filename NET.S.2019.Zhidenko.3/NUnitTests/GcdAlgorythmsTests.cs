using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._3;

namespace NUnitTests
{
    [TestFixture]
    public class GcdAlgorythmsTests
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(1, 10, 5, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 5)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(5, 10, 15, 20, 25, 30, ExpectedResult = 5)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(5, 5, 0, ExpectedResult = 5)]
        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(-5, 5, 0, ExpectedResult = 5)]
        [TestCase(-5, 5, -5, ExpectedResult = 5)]
        public int EuclideanGcd_with_correct_data(params int[] numbers)
        {
            return GcdAlgorythms.EuclideanGcd(numbers);
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(1, 10, 5, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 5)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(5, 10, 15, 20, 25, 30, ExpectedResult = 5)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(5, 5, 0, ExpectedResult = 5)]
        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(-5, 5, 0, ExpectedResult = 5)]
        [TestCase(-5, 5, -5, ExpectedResult = 5)]
        public int SteinGcd_with_correct_data(params int[] numbers)
        {
            return GcdAlgorythms.SteinGcd(numbers);
        }
    }
}
