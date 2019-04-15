using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PageCountDecorator : BookDecorator
    {
        public PageCountDecorator(IFormattedBook book) : base(book)
        {
        }

        public override string ToFormattedString()
        {
            return Book.ToFormattedString() + "Count of page - " + (Book as Book).PageCount;
        }
    }
}
