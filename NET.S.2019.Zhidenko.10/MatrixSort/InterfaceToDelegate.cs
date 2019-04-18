using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort
{
    public class InterfaceToDelegate
    {
        public InterfaceToDelegate(IComparer<int[]> comparer)
        {
            ComparerMethod = comparer.Compare;
        }

        public Func<int[], int[], int> ComparerMethod
        {
            get;
            private set;
        }
    }
}
