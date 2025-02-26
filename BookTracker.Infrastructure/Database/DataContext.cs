using Microsoft.EntityFrameworkCore;
using BookTracker.Infrastructure.Contracts.Database;

namespace BookTracker.Infrastructure.Database;

public class DataContext : DbContext, IDataContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}
}
