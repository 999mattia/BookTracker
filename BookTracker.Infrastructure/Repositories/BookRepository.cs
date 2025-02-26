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

	public IList<Book> GetAllBooks()
	{
		return dataContext.Books.ToList();
	}

	public Book GetBookById(Guid bookId)
	{
		return dataContext.Books.FirstOrDefault(b => b.Id == bookId);
	}

	public Book GetBookByTitle(string bookTitle)
	{
		return dataContext.Books.FirstOrDefault(b => b.Title == bookTitle);
	}

	public void SaveChanges()
	{
		dataContext.SaveChanges();
	}
}
