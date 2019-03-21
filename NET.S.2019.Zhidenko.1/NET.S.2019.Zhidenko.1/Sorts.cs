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
        /// Sorts array by quick sort algorythm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        public static void QuickSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            QuickSortRecursion(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursion part of quick sort algorythm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="start">Index of first element of array</param>
        /// <param name="end">Index of last element of array</param>
        private static void QuickSortRecursion(int[] array, int start, int end)
        {
            int middleElement = array[(end - start) / 2 + start];
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (array[i] < middleElement && i <= end) //Finds next element to swap in left part
                    i++;
                while (array[j] > middleElement && j >= start) //Finds next element to swap in right part 
                    j--;

                if (i <= j)
                {
                    SwapArrayElements(array, i, j);
                    i++;
                    j--;
                }

                if (j > start) // if there aremore than one element in left part 
                    QuickSortRecursion(array, start, j);
                if (i < end) // if there aremore than one element in right part
                    QuickSortRecursion(array, i, end);
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
        /// Sorts array by merge sort algorythm
        /// </summary>
        /// <param name="array">Unsorted array</param>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length == 0)
                throw new ArgumentException();

            if (array.Length == 1)
                return array;

            int middle = array.Length / 2;
            return MergeArrays(MergeSort(array.Take(middle).ToArray()), MergeSort(array.Skip(middle).ToArray()));
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
                //if not the end of the first and second array
                if (firstArrayElem < firstArray.Length && secondArrayElem < secondArray.Length)
                {
                    //add element from the first array or second depending on which element is smaller
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
                    //add last element from the first or second array
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
