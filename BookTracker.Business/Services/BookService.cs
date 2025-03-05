using BookTracker.Business.Contracts.Services;
using BookTracker.Core.Exceptions;
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

	public IEnumerable<Book> GetAllBooks()
	{
		return bookRepository.GetAllBooks();
	}

	public Book GetBookById(Guid bookId)
	{
		var book = bookRepository.GetBookById(bookId);

		if (book == null)
		{
			throw new NotFoundException($"Book with ID '{bookId}' not found");
		}

		return book;
	}

	public IEnumerable<Book> GetBooksByTitle(string bookTitle)
	{
		var books = bookRepository.GetBooksByTitle(bookTitle);

		if (books == null || !books.Any())
		{
			throw new NotFoundException($"No books found with title '{bookTitle}'");
		}

		return bookRepository.GetBooksByTitle(bookTitle);
	}

	public Book AddBook(Book bookToAdd)
	{
		bookRepository.AddBook(bookToAdd);

		bookRepository.SaveChanges();

		return bookToAdd;
	}
}
