using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PublisherDecorator : BookDecorator
    {
        public PublisherDecorator(IFormattedBook book) : base(book)
        {
        }

        public override string ToFormattedString()
        {
            return Book.ToFormattedString() + "Publisher - " + (Book as Book).Publisher;
        }
    }
}