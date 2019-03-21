using System;
using NUnit.Framework;
using NET.S._2019.Zhidenko._1;

namespace SortsTests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void QuickSortTestMethod_Valid_Array()
        {
            //Arange
            int[] initialArray = new int[] { 2, 6, 3, 2, 1 };
            int[] expectedArray = new int[] { 1, 2, 2, 3, 6 };

            //Act
            Sorts.QuickSort(initialArray);

            //Assert
            Assert.AreEqual(expectedArray, initialArray);
        }

        [Test]
        public void QuickSortTestMethod_Null_Array()
        {
            //Arange
            int[] initialArray = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => Sorts.QuickSort(initialArray));
        }

        [Test]
        public void QuickSortTestMethod_Empty_Array()
        {
            //Arange
            int[] initialArray = new int[] { };

            //Assert
            Assert.Throws<ArgumentException>(() => Sorts.QuickSort(initialArray));
        }

        [Test]
        public void MergeSortTestMethod_Valid_Array()
        {
            //Arange
            int[] initialArray = new int[] { 2, 6, 3, 2, 1 };
            int[] sortedArray;
            int[] expectedArray = new int[] { 1, 2, 2, 3, 6 };

            //Act
            sortedArray = Sorts.MergeSort(initialArray);

            //Assert
            Assert.AreEqual(expectedArray, sortedArray);
        }

        [Test]
        public void MergeSortTestMethod_Null_Array()
        {
            //Arange
            int[] initialArray = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => Sorts.QuickSort(initialArray));
        }

        [Test]
        public void MergeSortTestMethod_Empty_Array()
        {
            //Arange
            int[] initialArray = new int[] { };

            //Assert
            Assert.Throws<ArgumentException>(() => Sorts.QuickSort(initialArray));
        }
    }
}
