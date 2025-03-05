using System.ComponentModel.DataAnnotations;

namespace BookTracker.Core.DTOs;

public class BookDTO
{
	public Guid Id { get; set; }

	[Required]
	[MaxLength(100)]
	[MinLength(1)]
	public string Title { get; set; }

	[Required]
	[MaxLength(100)]
	[MinLength(1)]
	public string Author { get; set; }

	[MaxLength(1000)]
	public string? Description { get; set; }
}
