using AutoMapper;
using BookTracker.Core.DTOs;
using BookTracker.Core.Models;

namespace BookTracker.Presentation.Mapping;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<BookDTO, Book>();

		CreateMap<Book, BookDTO>();
	}
}
