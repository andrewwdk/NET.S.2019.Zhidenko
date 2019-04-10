using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8.Search
{
    public interface ISearchable
    {
        List<Book> FindBooksByTag(List<Book> list);
    }
}
