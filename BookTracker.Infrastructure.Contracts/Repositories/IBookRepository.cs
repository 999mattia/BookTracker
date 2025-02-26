using BookTracker.Core.Models;

namespace BookTracker.Infrastructure.Contracts.Repositories;

public interface IBookRepository
{
	IList<Book> GetAllBooks();

	Book GetBookById(Guid bookId);

	Book GetBookByTitle(string bookTitle);

	void SaveChanges();
}
