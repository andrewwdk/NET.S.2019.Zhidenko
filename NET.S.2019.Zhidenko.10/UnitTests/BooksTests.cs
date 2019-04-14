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
            IFormattedBook b = new Book("1", "name1", "author1", "publisher1", 2019, 100, 10);

            b = new NameDecorator(b);

            Assert.AreEqual("Book: Name - name1", b.ToFormattedString());
        }
    }
}
