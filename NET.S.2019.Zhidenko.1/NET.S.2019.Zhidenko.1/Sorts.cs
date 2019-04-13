using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._1
{
    public class Sorts
    {
        /// <summary>
        /// Sorts array by quick sort algorithm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            QuickSortRecursion(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts array by merge sort algorithm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            return MergeArrays(MergeSort(array.Take(middle).ToArray()), MergeSort(array.Skip(middle).ToArray()));
        }

        /// <summary>
        /// Recursion part of quick sort algorithm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="start">Index of first element of array</param>
        /// <param name="end">Index of last element of array</param>
        private static void QuickSortRecursion(int[] array, int start, int end)
        {
            int middleElement = array[((end - start) / 2) + start];
            int i = start;
            int j = end;

            while (i <= j)
            {
                // Finds next element to swap in left part
                while (array[i] < middleElement && i <= end) 
                {
                    i++;
                }

                // Finds next element to swap in right part 
                while (array[j] > middleElement && j >= start) 
                {
                    j--;
                }

                if (i <= j)
                {
                    SwapArrayElements(array, i, j);
                    i++;
                    j--;
                }

                // if there aremore than one element in left part 
                if (j > start) 
                {
                    QuickSortRecursion(array, start, j);
                }

                // if there aremore than one element in right part
                if (i < end) 
                {
                    QuickSortRecursion(array, i, end);
                }
            }
        }

        /// <summary>
        /// Swap two elements of array
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="start">Index of the first element to swap</param>
        /// <param name="end">Index of the second element to swap</param>
        private static void SwapArrayElements(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        /// <summary>
        /// Merge two arrays in descending order
        /// </summary>
        /// <param name="firstArray">The first array</param>
        /// <param name="secondArray">The second array</param>
        /// <returns>Merged array in descending order</returns>
        private static int[] MergeArrays(int[] firstArray, int[] secondArray)
        {
            int firstArrayElem = 0, secondArrayElem = 0;
            int[] mergedArray = new int[firstArray.Length + secondArray.Length];

            for (int i = 0; i < mergedArray.Length; i++)
            {
                // If not the end of the first and second array
                if (firstArrayElem < firstArray.Length && secondArrayElem < secondArray.Length)
                {
                    // Add element from the first array or second depending on which element is smaller
                    if (firstArray[firstArrayElem] > secondArray[secondArrayElem])
                    {
                        mergedArray[i] = secondArray[secondArrayElem];
                        secondArrayElem++;
                    }
                    else
                    {
                        mergedArray[i] = firstArray[firstArrayElem];
                        firstArrayElem++;
                    }
                }
                else
                {
                    // Add last element from the first or second array
                    if (secondArrayElem < secondArray.Length)
                    {
                        mergedArray[i] = secondArray[secondArrayElem];
                        secondArrayElem++;
                    }
                    else
                    {
                        mergedArray[i] = firstArray[firstArrayElem];
                        firstArrayElem++;
                    }
                }
            }

            return mergedArray;
        }
    }
}
