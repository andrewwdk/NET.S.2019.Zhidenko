1) a) Create class Book(ISBN, author, name, publisher, year of publishment, count of page, price).
   b) Override methods of Object.
   c) Implement interfaces(IEnumerable, IEqualateral).
   d) Create class BookListService for basic operations with collection of books:
	- AddBook(Add book if it does't exist. Otherwise throw exception);
	- RemoveBook(Remove book if it exists. Otherwise throw exception);
	- FindBookByTag(Find book by chosen criteria);
	- SortBooksByTag(Sort books by chosen criteria).
	Don't use delegates!
   e) Create class BookListStorage which allows to save and get data to/from it.
   f) Show work of classes in console application.
   g) Storage is a binary file(use only BinaryReader and BinaryWriter).
   Storage can be changed or added.

2) a) Create system of types to work with bank accounts(number, owner's name and surname, amount of money, bonus points).
   b) Bonus points increases/decreases every time when owner add/withdraw money to/from account.
   c) Bonus points calculates depending on "balance cost" and "addition cost".
   d) "Balance cost" and "addition cost" are integer values and depends on account gradation(Base, Gold, Platinum).
   e) Operations with account:
	- Add money to account;
	- Withdraw money from account;
	- Create new aacount;
	- Close account;
   f) Store account data in binary file.
   g) Show work of classes in console application.
   Remember about possibility:
	- to add new types of accounts;
	- to change/add source of storaging account data;
	- to change logic of calculating bonus points.
