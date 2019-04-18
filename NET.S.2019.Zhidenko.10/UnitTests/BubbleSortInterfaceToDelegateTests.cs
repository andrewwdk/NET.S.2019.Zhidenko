using System;
using MatrixSort;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class BubbleSortInterfaceToDelegateTests
    {
        [Test]
        public void SortBySum_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSortInterfaceToDelegate.SortBySum(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortBySum_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSortInterfaceToDelegate.SortBySum(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortBySum_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSortInterfaceToDelegate.SortBySum(ref actualArray, type));
        }

        [Test]
        public void SortBySum_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSortInterfaceToDelegate.SortBySum(ref actualArray, type));
        }

        [Test]
        public void SortByMaxElement_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSortInterfaceToDelegate.SortByMaxElement(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMaxElement_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSortInterfaceToDelegate.SortByMaxElement(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMaxElement_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSortInterfaceToDelegate.SortByMaxElement(ref actualArray, type));
        }

        [Test]
        public void SortByMaxElement_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSortInterfaceToDelegate.SortByMaxElement(ref actualArray, type));
        }

        [Test]
        public void SortByMinElement_Decreasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] actualArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] expectedArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.decreasing;

            BubbleSortInterfaceToDelegate.SortByMinElement(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMinElement_Increasing_WithCorrectData_ReturnsCorrectResult()
        {
            int[][] expectedArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 10 } };
            int[][] actualArray = new int[][] { new int[] { 10 }, new int[] { 4, 5 }, new int[] { 1, 2, 3 } };
            SortType type = SortType.increasing;

            BubbleSortInterfaceToDelegate.SortByMinElement(ref actualArray, type);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void SortByMinElement_WithNullArray_ReturnArgumentNullException()
        {
            int[][] actualArray = null;
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentNullException>(() => BubbleSortInterfaceToDelegate.SortByMinElement(ref actualArray, type));
        }

        [Test]
        public void SortByMinElement_WithEmptyArray_ReturnArgumentException()
        {
            int[][] actualArray = new int[][] { };
            SortType type = SortType.increasing;

            Assert.Throws<ArgumentException>(() => BubbleSortInterfaceToDelegate.SortByMinElement(ref actualArray, type));
        }
    }
}
