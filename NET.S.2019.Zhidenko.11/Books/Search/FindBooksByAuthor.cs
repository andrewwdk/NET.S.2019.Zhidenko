using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Search
{
    public class FindBooksByAuthor : ISearchable
    {
        public FindBooksByAuthor(string author)
        {
            Author = author;
        }

        public string Author { get; private set; }

        /// <summary> Finds book by author.</summary>
        /// <param name="initialList"> List to find in. </param>
        /// <returns> Found books.</returns>
        public List<Book> FindBooksByTag(List<Book> initialList)
        {
            List<Book> resultList = new List<Book>();

            foreach (Book book in initialList)
            {
                if (book.Author == Author)
                {
                    resultList.Add(book);
                }
            }

            return resultList;
        }
    }
}
