using System;
using System.Collections.Generic;
using System.IO;

namespace NET.S._2019.Zhidenko._8
{
    class BookListStorage
    {
        private string storagePath;

        public BookListStorage(string path)
        {
            StoragePath = path;
        }

        public string StoragePath
        {
            get
            {
                return storagePath;
            }

            private set
            {
                if(value == null || value == string.Empty)
                {
                    throw new ArgumentException("Path to book storage can't be empty string or null");
                }

                storagePath = value;
            }
        }

        /// <summary> Save list of books into file.</summary>
        /// <param name="list"> List of books. </param>
        public void PutBooksIntoStorage(List<Book> list)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(storagePath, FileMode.Create)))
            {
                foreach(Book book in list)
                {
                    writer.Write(book.Isbn);
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.Publisher);
                    writer.Write(book.PublicationYear);
                    writer.Write(book.PageCount);
                    writer.Write(book.Price);
                }
            }
        }

        /// <summary> Read list of books from file.</summary>
        /// <returns>List of books.</returns
        public List<Book> GetBooksFromStorage()
        {
            List<Book> list = new List<Book>();

            using(BinaryReader reader = new BinaryReader(File.Open(storagePath, FileMode.OpenOrCreate)))
            {
                while(reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var isbn = reader.ReadString();
                    var name = reader.ReadString();
                    var author = reader.ReadString();
                    var publisher = reader.ReadString();
                    var publicationYear = reader.ReadInt32();
                    var pageCount = reader.ReadInt32();
                    var price = reader.ReadInt32();

                    var book = new Book(isbn, name, author, publisher, publicationYear, pageCount, price);
                    list.Add(book);
                }
            }

            return list;
        }
    }
}
