using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public class PublicationYearDecorator : BookDecorator
    {
        public PublicationYearDecorator(IFormattedBook book) : base(book)
        {
        }

        public override string ToFormattedString()
        {
            return Book.ToFormattedString() + "Year of publication - " + (Book as Book).PublicationYear;
        }
    }
}
