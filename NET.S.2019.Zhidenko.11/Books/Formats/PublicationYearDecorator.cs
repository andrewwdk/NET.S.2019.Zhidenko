using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PublicationYearDecorator : BookDecorator
    {
        public PublicationYearDecorator(Book book) : base(book)
        {
        }

        public override string ToString()
        {
            return Book.ToString() + " Year of publication - " + Book.PublicationYear;
        }
    }
}
