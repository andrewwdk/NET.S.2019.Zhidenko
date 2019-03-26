using System;
using System.Collections.Generic;
using NUnit.Framework;
using NET.S._2019.Zhidenko._2;

namespace NUnitTests
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void FilterDigits_with_list_7_1_2_3_17_70_5_minus7_and_digit_7_returns_7_17_70_minus7()
        {
            //Arrange
            List<int> initialList = new List<int>();
            initialList.AddRange(new int[] { 7, 1, 2, 3, 17, 70, 5, -7 });
            List<int> expectedList = new List<int>();
            expectedList.AddRange(new int[] { 7, 17, 70, -7 });
            List<int> actualList;
            int digit = 7;

            //Act
            actualList = Filter.FilterDigits(initialList, digit);

            //Assert
            Assert.AreEqual(expectedList, actualList);

        }

        [Test]
        public void FilterDigits_with_null_list_returns_ArgumentNullException()
        {
            //Arrange
            List<int> initialList = null;
            int digit = 7;

            //Assert
            Assert.Throws<ArgumentNullException>(() => Filter.FilterDigits(initialList, digit));
        }

        [Test]
        public void FilterDigits_with_empty_list_returns_ArgumentException()
        {
            //Arrange
            List<int> initialList = new List<int>();
            int digit = 7;

            //Assert
            Assert.Throws<ArgumentException>(() => Filter.FilterDigits(initialList, digit));
        }

        [Test]
        public void FilterDigits_with_invalid_digit_returns_ArgumentException()
        {
            //Arrange
            List<int> initialList = new List<int>();
            initialList.AddRange(new int[] { 1, 2, 7 });
            int digit = -7;

            //Assert
            Assert.Throws<ArgumentException>(() => Filter.FilterDigits(initialList, digit));
        }
    }
}
