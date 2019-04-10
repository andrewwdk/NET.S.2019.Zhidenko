using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8
{
    public class BookListService
    {
        private IStoragable storage;
        public List<Book> BookList { get; private set; }

        public BookListService(IStoragable storage)
        {
            Storage = storage;
            BookList = storage.GetBooksFromStorage();
        }

        public IStoragable Storage
        {
            get
            {
                return storage;
            }

            set
            {
                storage = value ?? throw new ArgumentNullException("Storage can't be null!");
            }
        }

        /// <summary> Add book to the list.</summary>
        /// <param name="book"> The book to add. </param>
        public void AddBook(Book book)
        {
            if (IfBookExists(book))
            {
                throw new ArgumentException("The book already exists!");
            }

            BookList.Add(book);
        }

        /// <summary> Remove book from the list.</summary>
        /// <param name="book"> The book to remove. </param>
        public void RemoveBook(Book book)
        {
            if (!IfBookExists(book))
            {
                throw new ArgumentException("The book doesn't exist!");
            }

            BookList.Remove(book);
        }

        /// <summary> Save list of books in storage.</summary>
        public void PutBooksIntoStorage()
        {
            storage.PutBooksIntoStorage(BookList);
        }

        /// <summary> Sorts list of book by chosen tag.</summary>
        /// <param name="tag"> Tag to sort by. </param>
        /// <returns> Sorted list of book by tag.</returns>
        public List<Book> SortBooksByTag(Sorts.ISortable tag)
        {
            if(tag == null)
            {
                throw new ArgumentNullException("Tag can't be null!");
            }

            return tag.SortBooksByTag(BookList).ToList();
        }

        /// <summary> Finds books in the list by chosen tag.</summary>
        /// <param name="tag"> Tag to find by. </param>
        /// <returns> List of found books by tag.</returns>
        public List<Book> FindBooksByTag(Search.ISearchable tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("Tag can't be null!");
            }

            return tag.FindBooksByTag(BookList);
        }

        /// <summary> Check if the list contains the book.</summary>
        /// <param name="book"> The book to check. </param>
        /// <returns> Existance check result.</returns>
        private bool IfBookExists(Book book)
        {
            if(book == null)
            {
                return false;
            }

            foreach(Book currentBook in BookList)
            {
                if (currentBook.Equals(book))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
