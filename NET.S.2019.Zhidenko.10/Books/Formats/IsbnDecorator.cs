using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class IsbnDecorator : BookDecorator
    {
        public IsbnDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Isbn - " + Book.Isbn;
        }
    }
}
