using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class IntComparerByAbs : IComparer<int>
    {
        /// <summary> Compare two integer values.</summary>
        /// <param name="firstValue"> First value. </param>
        /// <param name="secondValue"> Second value. </param>
        /// <returns> Comparison result. </returns>
        public int Compare(int firstValue, int secondValue)
        {
            if (Math.Abs(firstValue) < Math.Abs(secondValue))
            {
                return -1;
            }

            if (Math.Abs(firstValue) > Math.Abs(secondValue))
            {
                return 1;
            }

            return 0;
        }
    }
}
