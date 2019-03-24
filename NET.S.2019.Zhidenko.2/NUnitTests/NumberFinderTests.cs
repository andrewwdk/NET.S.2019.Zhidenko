using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._2;

namespace NUnitTests
{
    public class NumberFinderTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = null)]
        [TestCase(20, ExpectedResult = null)]
        public int? Method_with_valid_data(int number)
        {
            return NumberFinder.FindNextBiggerNumber(number);
        }

        [TestCase(-10)]
        public void Method_with_negative_number_returns_ArgumentExeption(int number)
        {
            Assert.Throws<ArgumentException>(() => NumberFinder.FindNextBiggerNumber(number));
        }

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, null)]
        [TestCase(20, null)]
        public void Method_StopWatch_with_valid_data(int number, int? expected)
        {
            long time;
            int? result = NumberFinder.FindNextBiggerNumberAndGetTimeByStopWatch(number, out time);

            Assert.GreaterOrEqual(time, 0);
            Assert.AreEqual(expected, result);
        }

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, null)]
        [TestCase(20, null)]
        public void Method_Timer_with_valid_data(int number, int? expected)
        {
            long time;
            int? result = NumberFinder.FindNextBiggerNumberAndGetTimeByTimer(number, out time);

            Assert.GreaterOrEqual(time, 0);
            Assert.AreEqual(expected, result);
        }
    }
}
