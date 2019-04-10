using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zhidenko._8
{
    interface IStoragable
    {
        void PutBooksIntoStorage(List<Book> list);
        List<Book> GetBooksFromStorage();
    }
}
