using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class StringComparerByLength : IComparer<string>
    {
        /// <summary> Compare two string values.</summary>
        /// <param name="firstString"> First value. </param>
        /// <param name="secondString"> Second value. </param>
        /// <returns> Comparison result. </returns>
        public int Compare(string firstString, string secondString)
        {
            if (firstString == null)
            {
                if (secondString == null)
                {
                    return 0;
                }

                return -1;
            }

            if (secondString == null)
            {
                return 1;
            }

            if (firstString.Length < secondString.Length)
            {
                return -1;
            }

            if (firstString.Length  > secondString.Length)
            {
                return 1;
            }

            return 0;
        }
    }
}
