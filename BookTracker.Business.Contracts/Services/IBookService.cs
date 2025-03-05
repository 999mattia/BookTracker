namespace BookTracker.Business.Contracts.Services;
using BookTracker.Core.Models;

public interface IBookService
{
	IEnumerable<Book> GetAllBooks();

	Book GetBookById(Guid bookId);

	IEnumerable<Book> GetBooksByTitle(string bookTitle);

	Book AddBook(Book bookToAdd);

	Book UpdateBook(Guid bookId, Book bookToUpdate);

	void DeleteBook(Guid bookId);
}
