using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._2;

namespace NUnitTests
{
    [TestFixture]
    public class InsertTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int Method_returns_correct_result(int firstNumber, int secondNumber, int i, int j)
        {
            return BitsInsert.InsertNumber(firstNumber, secondNumber, i, j);
        }

        [TestCase(15, 15, 4, 3)]
        [TestCase(-8, -15, 0, 0)]
        public void Method_with_invalid_data_returns_ArgumentExeption(int firstNumber, int secondNumber, int i, int j)
        {
            Assert.Throws<ArgumentException>(() => BitsInsert.InsertNumber(firstNumber, secondNumber, i, j));
        }
    }
}
