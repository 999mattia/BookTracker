namespace BookTracker.Business.Contracts.Services;
using BookTracker.Core.Models;

public interface IBookService
{
	IList<Book> GetAllBooks();

	Book GetBookById(Guid bookId);

	IList<Book> GetBooksByTitle(string bookTitle);

	Book AddBook(Book bookToAdd);
}
