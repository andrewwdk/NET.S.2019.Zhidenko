using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort
{
    public class DelegateToInterface : IComparer<int[]>
    {
        private Func<int[], int[], int> comparer;

        public DelegateToInterface(Func<int[], int[], int> method)
        {
            comparer = method;
        }

        /// <summary> Compare two arrays of integers </summary>
        /// <param name="x"> First array</param>
        /// <param name="y"> Second array</param>
        /// <returns> Comparison result</returns>
        public int Compare(int[] x, int[] y)
        {
            return comparer(x, y);
        }
    }
}
