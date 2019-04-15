using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class AuthorDecorator : BookDecorator
    {
        public AuthorDecorator(IFormattedBook book) : base(book)
        {
        }

        public override string ToFormattedString()
        {
            return Book.ToFormattedString() + "Author - " + (Book as Book).Author;
        }
    }
}