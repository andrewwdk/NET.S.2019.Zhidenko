using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Books
{
    public class BookListService
    {
        private IStoragable storage;
        Logger logger;

        public BookListService(IStoragable storage)
        {
            logger = LogManager.GetCurrentClassLogger();
            Storage = storage;
            BookList = storage.GetBooksFromStorage();
        }

        public List<Book> BookList { get; private set; }

        public IStoragable Storage
        {
            get
            {
                return storage;
            }

            set
            {
                if(value != null)
                {
                    storage = value;
                }
                else
                {
                    logger.Error("Storage is null.");
                    throw new ArgumentNullException("Storage can't be null!");
                }
            }
        }

        /// <summary> Add book to the list.</summary>
        /// <param name="book"> The book to add. </param>
        public void AddBook(Book book)
        {
            if (IfBookExists(book))
            {
                logger.Error("The book already exists!");
                throw new ArgumentException("The book already exists!");
            }

            BookList.Add(book);
            logger.Info("Book was added successfully");
        }

        /// <summary> Remove book from the list.</summary>
        /// <param name="book"> The book to remove. </param>
        public void RemoveBook(Book book)
        {
            if (!IfBookExists(book))
            {
                logger.Error("The book doesn't exist!");
                throw new ArgumentException("The book doesn't exist!");
            }

            BookList.Remove(book);
            logger.Info("Book was removed successfully");
        }

        /// <summary> Save list of books in storage.</summary>
        public void PutBooksIntoStorage()
        {
            try
            {
                storage.PutBooksIntoStorage(BookList);
            }
            catch (Exception e)
            {
                logger.Error("Books were not saved into storage. {0}", e.Message);
            }

            logger.Info("Books were saved into storage successfully");
        }

        /// <summary> Sorts list of book by chosen tag.</summary>
        /// <param name="tag"> Tag to sort by. </param>
        /// <returns> Sorted list of book by tag.</returns>
        public List<Book> SortBooksByTag(Sorts.ISortable tag)
        {
            if (tag == null)
            {
                logger.Error("Sort tag can't be null!");
                throw new ArgumentNullException("Tag can't be null!");
            }

            logger.Debug("Sorting by tag");
            return tag.SortBooksByTag(BookList).ToList();
        }

        /// <summary> Finds books in the list by chosen tag.</summary>
        /// <param name="tag"> Tag to find by. </param>
        /// <returns> List of found books by tag.</returns>
        public List<Book> FindBooksByTag(Search.ISearchable tag)
        {
            if (tag == null)
            {
                logger.Error("Search tag can't be null!");
                throw new ArgumentNullException("Tag can't be null!");
            }

            logger.Debug("Searching for books by tag");
            return tag.FindBooksByTag(BookList);
        }

        /// <summary> Check if the list contains the book.</summary>
        /// <param name="book"> The book to check. </param>
        /// <returns> Existence check result.</returns>
        private bool IfBookExists(Book book)
        {
            logger.Debug("Checking existance of the book");

            if (book == null)
            {
                return false;
            }

            foreach (Book currentBook in BookList)
            {
                if (currentBook.Equals(book))
                {
                    logger.Debug("The book was found");
                    return true;
                }
            }

            logger.Debug("The book wasn't found");
            return false;
        }
    }
}
