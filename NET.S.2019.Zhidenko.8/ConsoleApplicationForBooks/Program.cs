using System;
using System.Collections.Generic;
using NET.S._2019.Zhidenko._8;
using NET.S._2019.Zhidenko._8.Search;
using NET.S._2019.Zhidenko._8.Sorts;

namespace ConsoleApplicationForBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService(new BookListStorage("D:\\Курсы\\file.txt"));

            service.AddBook(new Book("1", "Name1", "Author1", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("2", "Name2", "Author1", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("3", "Name3", "Author1", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("4", "Name4", "Author2", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("5", "Name5", "Author2", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("6", "Name1", "Author2", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("7", "Name8", "Author0", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("8", "Name7", "Author0", "Publisher1", 2010, 200, 10));
            service.AddBook(new Book("9", "Name1", "Author0", "Publisher1", 2010, 200, 10));

            //var list = service.FindBooksByTag(new FindBooksByAuthor("Author0"));
            //var list = service.FindBooksByTag(new FindBooksByName("Name1"));

            //var list = service.SortBooksByTag(new SortByAuthor());
            //var list = service.SortBooksByTag(new SortByName());
            //var list = service.SortBooksByTag(new SortByAuthorAndName());

            //service.RemoveBook(new Book("9", "Name1", "Author0", "Publisher1", 2010, 200, 10));
            //var list = service.BookList;

            service.PutBooksIntoStorage();
            BookListService newService = new BookListService(new BookListStorage("D:\\Курсы\\file.txt"));
            var list = newService.BookList;

            foreach (Book book in list)
            {
                Console.WriteLine(book.ToString());
            }

            Console.ReadKey();
        }
    }
}
