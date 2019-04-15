using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PublisherDecorator : BookDecorator
    {
        public PublisherDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Publisher - " + Book.Publisher;
        }
    }
}