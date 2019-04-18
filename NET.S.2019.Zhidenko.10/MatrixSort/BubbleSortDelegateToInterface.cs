using System;
using System.Collections.Generic;

namespace MatrixSort
{
    /// <summary> Define type of sort: increasing or decreasing </summary>
    public enum SortType
    {
        increasing,
        decreasing
    }

    public class BubbleSortDelegateToInterface
    {
        /// <summary> Sorts jagged array of integers by sum of elements</summary>
        /// <param name="array">Array to sort</param>
        /// <param name="type">Sort order</param>
        public static void SortBySum(ref int[][] array, SortType type)
        {
            Func<int[], int[], int> comparer = CompareBySum;
            BubbleSort(ref array, new DelegateToInterface(comparer), type);
        }

        /// <summary> Sorts jagged array of integers by max element</summary>
        /// <param name="array">Array to sort</param>
        /// <param name="type">Sort order</param>
        public static void SortByMaxElement(ref int[][] array, SortType type)
        {
            Func<int[], int[], int> comparer = CompareByMaxElement;
            BubbleSort(ref array, new DelegateToInterface(comparer), type);
        }

        /// <summary> Sorts jagged array of integers by min element</summary>
        /// <param name="array">Array to sort</param>
        /// <param name="type">Sort order</param>
        public static void SortByMinElement(ref int[][] array, SortType type)
        {
            Func<int[], int[], int> comparer = CompareByMinElement;
            BubbleSort(ref array, new DelegateToInterface(comparer), type);
        }

        /// <summary> Sorts jagged array of integers by certain criteria</summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Sort criteria</param>
        /// <param name="type">Sort order</param>
        private static void BubbleSort(ref int[][] array, IComparer<int[]> comparer, SortType type)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (type == SortType.increasing)
                    {
                        if (comparer.Compare(array[i], array[j]) == 1)
                        {
                            SwapArrays(ref array[i], ref array[j]);
                        }
                    }
                    else
                    {
                        if (comparer.Compare(array[i], array[j]) == -1)
                        {
                            SwapArrays(ref array[i], ref array[j]);
                        }
                    }
                }
            }
        }

        /// <summary> Compares two arrays of integers by sum of elements</summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        /// <returns>Comparison result</returns>
        private static int CompareBySum(int[] firstArray, int[] secondArray)
        {
            if (GetSum(firstArray) == GetSum(secondArray))
            {
                return 0;
            }

            if (GetSum(firstArray) < GetSum(secondArray))
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary> Compares two arrays of integers by max element</summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        /// <returns>Comparison result</returns>
        private static int CompareByMaxElement(int[] firstArray, int[] secondArray)
        {
            if (FindMaxElement(firstArray) == FindMaxElement(secondArray))
            {
                return 0;
            }

            if (FindMaxElement(firstArray) < FindMaxElement(secondArray))
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary> Compares two arrays of integers by min element</summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        /// <returns>Comparison result</returns>
        private static int CompareByMinElement(int[] firstArray, int[] secondArray)
        {
            if (FindMinElement(firstArray) == FindMinElement(secondArray))
            {
                return 0;
            }

            if (FindMinElement(firstArray) < FindMinElement(secondArray))
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary> Finds sum of all elements in the array </summary>
        /// <param name="array">Array to find sum</param>
        /// <returns>Sum of elements</returns>
        private static int GetSum(int[] array)
        {
            int sum = 0;

            foreach (int number in array)
            {
                sum += number;
            }

            return sum;
        }

        /// <summary> Finds max element in the array </summary>
        /// <param name="array">Array to find max element</param>
        /// <returns>Max element</returns>
        private static int FindMaxElement(int[] array)
        {
            int maxElement = int.MinValue;

            foreach (int number in array)
            {
                if (number > maxElement)
                {
                    maxElement = number;
                }
            }

            return maxElement;
        }

        /// <summary>Finds min element in the array</summary>
        /// <param name="array">Array to find min element</param>
        /// <returns>Min element</returns>
        private static int FindMinElement(int[] array)
        {
            int minElement = int.MaxValue;

            foreach (int number in array)
            {
                if (number < minElement)
                {
                    minElement = number;
                }
            }

            return minElement;
        }

        /// <summary> Swap two array </summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        private static void SwapArrays(ref int[] firstArray, ref int[] secondArray)
        {
            int[] temp = firstArray;
            firstArray = secondArray;
            secondArray = temp;
        }
    }
}
