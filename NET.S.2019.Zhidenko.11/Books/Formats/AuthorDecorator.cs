using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class AuthorDecorator : BookDecorator
    {
        public AuthorDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Author - " + Book.Author;
        }
    }
}