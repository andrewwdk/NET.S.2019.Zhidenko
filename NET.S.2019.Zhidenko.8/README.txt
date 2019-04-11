1) a) Create class Book(ISBN, author, name, publisher, year of publishment, count of page, price).
   b) Override methods of Object.
   c) Implement interfaces(IEnumerable, IEqualateral).
   d) Create class BookListService for basic operations with collection of books:
	- AddBook(Add book if it does't exist. Otherwise throw exception);
	- RemoveBook(Remove book if it exists. Otherwise throw exception);
	- FindBookByTag(Find book by chosen criteria);
	- SortBooksByTag(Sort books by chosen criteria);
	Don't use delegates!
   e) Create class BookListStorage which allows to save and get data to/from it.
   f) Show work of classes in console application.
   g) Storage is a binary file(use only BinaryReader and BinaryWriter).
   Storage can be changed or added.