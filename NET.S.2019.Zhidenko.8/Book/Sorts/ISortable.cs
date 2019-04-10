using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8.Sorts
{
    public interface ISortable
    {
        IEnumerable<Book> SortBooksByTag(List<Book> list);
    }
}
