using AutoMapper;
using BookTracker.Business.Contracts.Services;
using BookTracker.Core.DTOs;
using BookTracker.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Presentation.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
	private IMapper mapper { get; }
	private IBookService bookService { get; }

	public BookController(IMapper mapper, IBookService bookService)
	{
		this.mapper = mapper;
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

	[HttpPost]
	[Authorize(Roles = "admin")]
	public IActionResult AddBook(BookDTO bookToAdd)
	{
		var mappedBookToAdd = mapper.Map<BookDTO, Book>(bookToAdd);

		return Ok(bookService.AddBook(mappedBookToAdd));
	}
}
