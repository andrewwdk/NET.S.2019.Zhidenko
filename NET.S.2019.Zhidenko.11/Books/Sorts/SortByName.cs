using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Sorts
{
    public class SortByName : ISortable
    {
        /// <summary> Sort list of books by name.</summary>
        /// <param name="list"> List of books. </param>
        /// <returns> Sorted IEnumerable.</returns>D:\Курсы\NET.S.2019.Zhidenko.10\Books\Sorts\SortByName.cs
        public IEnumerable<Book> SortBooksByTag(List<Book> list)
        {
            return list.OrderBy(book => book.Name).Select(book => book);       
        }
    }
}
