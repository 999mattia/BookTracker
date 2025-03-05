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

	public IList<Book> GetBooksByTitle(string bookTitle)
	{
		return dataContext.Books
			.Where(b => b.Title.ToLower().Contains(bookTitle.ToLower()))
			.ToList();
	}

	public void AddBook(Book bookToAdd)
	{
		dataContext.Add(bookToAdd);
	}

	public void SaveChanges()
	{
		dataContext.SaveChanges();
	}
}
