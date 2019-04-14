using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Formats
{
    public interface IFormattedBook
    {
        string ToFormattedString();
    }
}
