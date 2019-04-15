using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public abstract class BookDecorator : Book
    {
        protected BookDecorator(Book book) : 
            base(book.Isbn, book.Name, book.Author, book.Publisher, book.PublicationYear, book.PageCount, book.Price)
        {
            Book = book;
        }

        public Book Book { get; private set; }

        public abstract override string ToString();
    }
}
