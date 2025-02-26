using BookTracker.Business.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Presentation.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
	private IBookService bookService { get; }

	public BookController(IBookService bookService)
	{
		this.bookService = bookService;
	}

	[HttpGet]
	[Authorize(Roles = "user,admin")]
	public IActionResult GetAllBooks([FromQuery] string? title)
	{
		if (!string.IsNullOrEmpty(title))
		{
			var books = bookService.GetBooksByTitle(title);

			if (books == null || !books.Any())
			{
				return NotFound($"No books found with title '{title}'.");
			}

			return Ok(books);
		}

		return Ok(bookService.GetAllBooks());
	}

	[HttpGet("{id:guid}")]
	[Authorize(Roles = "user,admin")]
	public IActionResult GetBookById(Guid id)
	{
		var book = bookService.GetBookById(id);

		if (book == null)
		{
			return NotFound($"Book with ID {id} not found.");
		}

		return Ok(book);
	}
}
