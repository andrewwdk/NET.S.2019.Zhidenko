using System;
using System.Collections.Generic;
using NUnit.Framework;
using Search;


namespace NUnitTests
{
    [TestFixture]
    public class BinaryTests
    {
        [Test]
        public void BinarySearch_OfIntContainedValue_ReturnsCorrectResult()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var searchedValue = 4;
            var comparer = Comparer<int>.Default;
            var expectedResult = true;

            var actualResult = Binary.BinarySearch<int>(array, searchedValue, comparer);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BinarySearch_OfIntNotContainedValue_ReturnsCorrectResult()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var searchedValue = 6;
            var comparer = Comparer<int>.Default;
            var expectedResult = false;

            var actualResult = Binary.BinarySearch<int>(array, searchedValue, comparer);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BinarySearch_OfStringContainedValue_ReturnsCorrectResult()
        {
            var array = new string[] { "a", "b", "c", "d", "e" };
            var searchedValue = "d";
            var comparer = Comparer<string>.Default;
            var expectedResult = true;

            var actualResult = Binary.BinarySearch<string>(array, searchedValue, comparer);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BinarySearch_OfStringNotContainedValue_ReturnsCorrectResult()
        {
            var array = new string[] { "a", "b", "c", "d", "e" };
            var searchedValue = "f";
            var comparer = Comparer<string>.Default;
            var expectedResult = false;

            var actualResult = Binary.BinarySearch<string>(array, searchedValue, comparer);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
