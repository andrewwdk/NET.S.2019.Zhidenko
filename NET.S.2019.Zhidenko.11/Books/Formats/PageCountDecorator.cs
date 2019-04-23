using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PageCountDecorator : BookDecorator
    {
        public PageCountDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Count of page - " + Book.PageCount;
        }
    }
}
