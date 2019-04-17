using System;
using Books;
using Books.Formats;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BooksTests
    {
        [Test]
        public void FormattedBookByName_ReturnsCorrectResult()
        {
            Book b = new Book("1", "name1", "author1", "publisher1", 2019, 100, 10);
            string expectedString = "Book: Name - name1";

            b = new NameDecorator(b);

            Assert.AreEqual(expectedString, b.ToString());
        }

        [Test]
        public void FormattedBookByAllFields_ReturnsCorrectResult()
        {
            Book b = new Book("1", "name1", "author1", "publisher1", 2019, 100, 10);
            string expectedString = "Book: Isbn - 1 Name - name1 Author - author1 Publisher - publisher1 " +
                "Year of publication - 2019 Count of page - 100 Price - 10";

            b = new IsbnDecorator(b);
            b = new NameDecorator(b);
            b = new AuthorDecorator(b);
            b = new PublisherDecorator(b);
            b = new PublicationYearDecorator(b);
            b = new PageCountDecorator(b);
            b = new PriceDecorator(b);

            Assert.AreEqual(expectedString, b.ToString());
        }

        [Test]
        public void FormattedToString_ReturnsCorrectResult()
        {
            Book b = new Book("1", "name1", "author1", "publisher1", 2019, 100, 10);
            string expectedString = "Book: Isbn - 1 Name - name1 Author - author1 Publisher - publisher1 " +
                "Year of publication - 2019 Count of page - 100 Price - 10";

            string actualString = b.ToString("INAPYCp", null);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
