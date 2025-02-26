using Microsoft.EntityFrameworkCore;
using BookTracker.Core.Models;

namespace BookTracker.Infrastructure.Contracts.Database;

public interface IDataContext
{
	DbSet<Book> Books { get; set; }

	int SaveChanges();
}