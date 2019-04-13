using System;

namespace NET.S._2019.Zhidenko._8
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        private string isbn;
        private string name;
        private string author;
        private int pageCount;
        private int price;
        private int publicationYear;
        private string publisher;

        public Book(string isbn, string name, string author, string publisher, int publicationYear, int pageCount, int price)
        {
            Isbn = isbn;
            Name = name;
            Author = author;
            Publisher = publisher;
            PublicationYear = publicationYear;
            PageCount = pageCount;
            Price = price;
        }

        public string Isbn
        {
            get
            {
                return isbn;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Isbn can't be null or empty!");
                }

                isbn = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Name can't be null or empty!");
                }

                name = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Author can't be null or empty!");
                }

                author = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Publisher can't be null or empty!");
                }

                publisher = value;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Count of page can't be 0 or less!");
                }

                pageCount = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can't be 0 or less!");
                }

                price = value;
            }
        }

        public int PublicationYear
        {
            get
            {
                return publicationYear;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Year of publication can't be 0 or less!");
                }

                publicationYear = value;
            }
        }

        /// <summary> Convert Book to string.</summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return "Isbn: " + Isbn + ", Name: " + Name + ", Author: " + Author + ", Publisher: " +
                Publisher + ", Year of publication: " + PublicationYear.ToString() + ", Count of page: " + 
                PageCount.ToString() + ", Price: " + Price.ToString();
        }

        /// <summary> Calculate hash code.</summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            var hashCode = 352033288;

            hashCode = (hashCode * -1521134295) + Isbn.GetHashCode();
            hashCode = (hashCode * -1521134295) + Name.GetHashCode();
            hashCode = (hashCode * -1521134295) + Author.GetHashCode();
            hashCode = (hashCode * -1521134295) + Publisher.GetHashCode();
            hashCode = (hashCode * -1521134295) + PublicationYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + Price.GetHashCode();
            hashCode = (hashCode * -1521134295) + PageCount.GetHashCode();

            return hashCode;
        }

        /// <summary> Compare Book with other book.</summary>
        /// <param name="obj"> Object to compare. </param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        /// <summary> Compare Book with other book.</summary>
        /// <param name="book"> Book to compare. </param>
        /// <returns>Comparison result.</returns>
        public bool Equals(Book book)
        {
            if (book == null)
            {
                return false;
            }

            if (Isbn == book.Isbn && Name == book.Name && Author == book.Author && Publisher == book.Publisher
                && PublicationYear == book.PublicationYear && Price == book.Price && PageCount == book.PageCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> Compare Book with other book.</summary>
        /// <param name="book"> Book to compare. </param>
        /// <returns>Comparison result.</returns>
        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }

            if (string.Compare(Name, book.Name) == 0 && string.Compare(Author, book.Author) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary> Compare Book with other book.</summary>
        /// <param name="obj"> Object to compare. </param>
        /// <returns>Comparison result.</returns>
        public int CompareTo(object obj)
        {
            return CompareTo(obj as Book);
        }
    }
}
