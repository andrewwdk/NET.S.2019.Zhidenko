using System;
using NET.S._2019.Zhidenko._5;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void SortBySum_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSort.SortBySum( actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortBySum_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSort.SortBySum(actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortBySum_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortBySum(actualArray, type));
        }

        [Test]
        public void SortBySum_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSort.SortBySum(actualArray, type));
        }

        [Test]
        public void SortByMaxElement_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSort.SortByMaxElement(actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMaxElement_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSort.SortByMaxElement(actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMaxElement_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMaxElement(actualArray, type));
        }

        [Test]
        public void SortByMaxElement_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSort.SortByMaxElement(actualArray, type));
        }

        [Test]
        public void SortByMinElement_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSort.SortByMinElement(actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMinElement_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSort.SortByMinElement(actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMinElement_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMinElement(actualArray, type));
        }

        [Test]
        public void SortByMinElement_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSort.SortByMinElement(actualArray, type));
        }
    }
}
