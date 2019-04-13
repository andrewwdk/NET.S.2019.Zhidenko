using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8.Sorts
{
    public class SortByName : ISortable
    {
        /// <summary> Sort list of books by name.</summary>
        /// <param name="list"> List of books. </param>
        /// <returns> Sorted IEnumerable.</returns>
        public IEnumerable<Book> SortBooksByTag(List<Book> list)
        {
            return list.OrderBy(book => book.Name).Select(book => book);       
        }
    }
}
