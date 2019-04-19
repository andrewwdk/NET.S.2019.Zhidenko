using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Binary
    {
        /// <summary> Search value in array by binary search algorithm</summary>
        /// <param name="array"> Array </param>
        /// <param name="searchedValue"> Value to find </param>
        /// <param name="comparer"> Comparator </param>
        /// <returns> Search result</returns>
        public static bool BinarySearch<T>(T[] array, T searchedValue, Comparer<T> comparer)
        {
            if (array == null || searchedValue == null || comparer == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            var bottom = 0;
            var top = array.Length - 1;
            int middle = top / 2;

            while (top >= bottom)
            {
                var compareResult = comparer.Compare(array[middle], searchedValue);

                if (compareResult == 0)
                {
                    return true;
                }

                if (compareResult == 1)
                {
                    top = middle - 1;
                }
                else
                {
                    bottom = middle + 1;
                }

                middle = (top + bottom) / 2;
            }

            return false;
        }
    }
}
