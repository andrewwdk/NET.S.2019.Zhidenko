using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Sorts
{
    public class SortByAuthorAndName : ISortable
    {
        /// <summary> Sort list of books by author and name.</summary>
        /// <param name="list"> List of books. </param>
        /// <returns> Sorted IEnumerable.</returns>
        public IEnumerable<Book> SortBooksByTag(List<Book> list)
        {
            return list.OrderBy(book => book.Author).ThenBy(book => book.Name).Select(book => book);
        }
    }
}
