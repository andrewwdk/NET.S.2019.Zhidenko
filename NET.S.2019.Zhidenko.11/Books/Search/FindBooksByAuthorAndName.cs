using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Search
{
    public class FindBooksByAuthorAndName : ISearchable
    {
        public FindBooksByAuthorAndName(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; private set; }

        public string Author { get; private set; }

        /// <summary> Finds book by name and author.</summary>
        /// <param name="initialList"> List to find in. </param>
        /// <returns> Found books.</returns>
        public List<Book> FindBooksByTag(List<Book> initialList)
        {
            List<Book> resultList = new List<Book>();

            foreach (Book book in initialList)
            {
                if (book.Name == Name && book.Author == Author)
                {
                    resultList.Add(book);
                }
            }

            return resultList;
        }
    }
}
