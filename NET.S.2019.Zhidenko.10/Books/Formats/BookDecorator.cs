using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public abstract class BookDecorator : IFormattedBook
    {
        protected BookDecorator(IFormattedBook book)
        {
            Book = book;
        }

        public IFormattedBook Book { get; private set; }

        public abstract string ToFormattedString();
    }
}
