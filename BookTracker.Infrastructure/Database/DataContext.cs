using BookTracker.Core.Models;
using BookTracker.Infrastructure.Contracts.Database;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Infrastructure.Database;

public class DataContext : DbContext, IDataContext
{
	public DbSet<Book> Books { get; set; }

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Book>(entity =>
		{
			entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
			entity.Property(e => e.Author).HasMaxLength(100).IsRequired();
			entity.Property(e => e.Description).HasMaxLength(1000);

			entity.HasIndex(e => e.Title);
		});

		base.OnModelCreating(modelBuilder);
	}
}
