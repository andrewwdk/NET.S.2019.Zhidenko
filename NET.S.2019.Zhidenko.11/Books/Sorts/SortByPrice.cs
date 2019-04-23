using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Sorts
{
    public class SortByPrice : ISortable
    {
        /// <summary> Sort list of books by price.</summary>
        /// <param name="list"> List of books. </param>
        /// <returns> Sorted IEnumerable.</returns>
        public IEnumerable<Book> SortBooksByTag(List<Book> list)
        {
            return list.OrderBy(book => book.Price).Select(book => book);
        }
    }
}
