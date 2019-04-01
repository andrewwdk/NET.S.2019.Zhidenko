using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._5
{
    public enum SortType
    {
        increasing,
        decreasing
    }

    public class BubbleSort
    {
        /// <summary> Sorts array of arrays by sum of elements in each array </summary>
        /// <param name="array">Array</param>
        /// <param name="type">Type of sort: increasing or decreasing</param>
        public static void SortBySum(int[][] array, SortType type)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            for(int i = 0; i < array.Length - 1; i++)
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(type == SortType.increasing)
                    {
                        if (GetSum(array[j]) < GetSum(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                    else
                    {
                        if (GetSum(array[j]) > GetSum(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                }
        }

        /// <summary> Sorts array of arrays by max element in each array </summary>
        /// <param name="array">Array</param>
        /// <param name="type">Type of sort: increasing or decreasing</param>
        public static void SortByMaxElement(int[][] array, SortType type)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (type == SortType.increasing)
                    {
                        if (FindMaxElement(array[j]) < FindMaxElement(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                    else
                    {
                        if (FindMaxElement(array[j]) > FindMaxElement(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                }
        }

        /// <summary> Sorts array of arrays by min element in each array </summary>
        /// <param name="array">Array</param>
        /// <param name="type">Type of sort: increasing or decreasing</param>
        public static void SortByMinElement(int[][] array, SortType type)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (type == SortType.increasing)
                    {
                        if (FindMinElement(array[j]) < FindMinElement(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                    else
                    {
                        if (FindMinElement(array[j]) > FindMinElement(array[i]))
                            SwapArrays(ref array[i], ref array[j]);
                    }
                }
        }

        /// <summary> Finds sum of all elements in the array </summary>
        /// <param name="array">Array</param>
        /// <returns>Sum of elements</returns>
        private static int GetSum(int[] array)
        {
            int sum = 0;

            foreach (int number in array)
                sum += number;

            return sum;
        }

        /// <summary> Finds max element in the array </summary>
        /// <param name="array">Array</param>
        /// <returns>Max element</returns>
        private static int FindMaxElement(int[] array)
        {
            int maxElement = int.MinValue;

            foreach (int number in array)
                if (number > maxElement)
                    maxElement = number;

            return maxElement;
        }

        /// <summary> Finds min element in the array </summary>
        /// <param name="array">Array</param>
        /// <returns>Min element</returns>
        private static int FindMinElement(int[] array)
        {
            int minElement = int.MaxValue;

            foreach (int number in array)
                if (number < minElement)
                    minElement = number;

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
