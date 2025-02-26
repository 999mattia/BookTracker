using BookTracker.Business.Contracts.Services;
using BookTracker.Core.Models;
using BookTracker.Infrastructure.Contracts.Repositories;

namespace BookTracker.Business.Services;

public class BookService : IBookService
{
	private IBookRepository bookRepository { get; }

	public BookService(IBookRepository bookRepository)
	{
		this.bookRepository = bookRepository;
	}

	public IList<Book> GetAllBooks()
	{
		return bookRepository.GetAllBooks();
	}

	public Book GetBookById(Guid bookId)
	{
		return bookRepository.GetBookById(bookId);
	}

	public IList<Book> GetBooksByTitle(string bookTitle)
	{
		return bookRepository.GetBooksByTitle(bookTitle);
	}
}
