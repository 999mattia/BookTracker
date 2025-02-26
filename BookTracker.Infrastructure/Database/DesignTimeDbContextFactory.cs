using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookTracker.Infrastructure.Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
	public DataContext CreateDbContext(string[] args)
	{
		var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
		var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

		var configuration = new ConfigurationBuilder()
			.SetBasePath(basePath)
			.AddJsonFile("BookTracker.Presentation/appsettings.json", optional: true)
			.AddJsonFile($"BookTracker.Presentation/appsettings.{environment}.json", optional: false)
			.Build();

		var connectionString = configuration.GetConnectionString("DatabaseConnection");

		var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
		optionsBuilder.UseNpgsql(connectionString);

		return new DataContext(optionsBuilder.Options);
	}

}
