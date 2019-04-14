using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Search
{
    public interface ISearchable
    {
        List<Book> FindBooksByTag(List<Book> list);
    }
}
