using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8.Search
{
    public class FindBooksByAuthorAndName
    {
        public string Name { get; private set; }
        public string Author { get; private set; }

        public FindBooksByAuthorAndName(string name, string author)
        {
            Name = name;
            Author = author;
        }

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
