using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PriceDecorator : BookDecorator
    {
        public PriceDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Price - " + Book.Price;
        }
    }
}
