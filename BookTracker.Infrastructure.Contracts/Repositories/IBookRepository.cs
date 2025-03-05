using BookTracker.Core.Models;

namespace BookTracker.Infrastructure.Contracts.Repositories;

public interface IBookRepository
{
	IList<Book> GetAllBooks();

	Book GetBookById(Guid bookId);

	IList<Book> GetBooksByTitle(string bookTitle);

	Book AddBook(Book bookToAdd);

	void SaveChanges();
}
