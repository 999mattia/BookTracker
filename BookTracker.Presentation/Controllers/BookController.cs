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
			return Ok(bookService.GetBooksByTitle(title));
		}

		return Ok(bookService.GetAllBooks());
	}

	[HttpGet("{id:guid}")]
	[Authorize(Roles = "user,admin")]
	public IActionResult GetBookById(Guid id)
	{
		return Ok(bookService.GetBookById(id));
	}
}
