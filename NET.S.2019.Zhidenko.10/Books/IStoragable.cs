using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public interface IStoragable
    {
        void PutBooksIntoStorage(List<Book> list);

        List<Book> GetBooksFromStorage();
    }
}
