using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class IsbnDecorator : BookDecorator
    {
        public IsbnDecorator(IFormattedBook book) : base(book)
        {
        }

        public override string ToFormattedString()
        {
            return Book.ToFormattedString() + "Isbn - " + (Book as Book).Isbn;
        }
    }
}
