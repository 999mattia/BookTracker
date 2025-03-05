using BookTracker.Core.Models;
using BookTracker.Infrastructure.Contracts.Repositories;
using BookTracker.Infrastructure.Database;

namespace BookTracker.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
	private DataContext dataContext { get; }

	public BookRepository(DataContext dataContext)
	{
		this.dataContext = dataContext;
	}

	public IEnumerable<Book> GetAllBooks()
	{
		return dataContext.Books;
	}

	public Book GetBookById(Guid bookId)
	{
		return dataContext.Books.FirstOrDefault(b => b.Id == bookId);
	}

	public IEnumerable<Book> GetBooksByTitle(string bookTitle)
	{
		return dataContext.Books
			.Where(b => b.Title.ToLower().Contains(bookTitle.ToLower()));
	}

	public void AddBook(Book bookToAdd)
	{
		dataContext.Books.Add(bookToAdd);
	}

	public void DeleteBook(Book bookToDelete)
	{
		dataContext.Books.Remove(bookToDelete);
	}

	public void SaveChanges()
	{
		dataContext.SaveChanges();
	}
}
