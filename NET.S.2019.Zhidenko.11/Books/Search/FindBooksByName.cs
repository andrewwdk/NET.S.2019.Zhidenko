using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Search
{
    public class FindBooksByName : ISearchable
    {
        public FindBooksByName(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        /// <summary> Finds book by name.</summary>
        /// <param name="initialList"> List to find in. </param>
        /// <returns> Found books.</returns>
        public List<Book> FindBooksByTag(List<Book> initialList)
        {
            List<Book> resultList = new List<Book>();

            foreach (Book book in initialList)
            {
                if (book.Name == Name)
                {
                    resultList.Add(book);
                }
            }

            return resultList;
        }
    }
}
