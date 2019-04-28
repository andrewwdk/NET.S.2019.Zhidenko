using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BookComparerByIsbn : IComparer<Book>
    {
        /// <summary> Compare two books.</summary>
        /// <param name="firstBook"> First book. </param>
        /// <param name="secondBook"> Second book. </param>
        /// <returns> Comparison result. </returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null)
            {
                if (secondBook == null)
                {
                    return 0;
                }

                return -1;
            }

            if (secondBook == null)
            {
                return 1;
            }

            return Comparer<string>.Default.Compare(firstBook.Isbn, secondBook.Isbn);
        }
    }
}
