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
	public IActionResult GetAllBooks()
	{
		return Ok(bookService.GetAllBooks());
	}
}
