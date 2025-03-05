using BookTracker.Core.Models;

namespace BookTracker.Infrastructure.Contracts.Repositories;

public interface IBookRepository
{
	IEnumerable<Book> GetAllBooks();

	Book GetBookById(Guid bookId);

	IEnumerable<Book> GetBooksByTitle(string bookTitle);

	void AddBook(Book bookToAdd);

	void DeleteBook(Book bookToDelete);

	void SaveChanges();
}
