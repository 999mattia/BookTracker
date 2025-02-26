using BookTracker.Infrastructure.Contracts.Repositories;
using BookTracker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Infrastructure.Extensions;

public static class RepositoryExtensions
{
	public static void AddRepositories(this IServiceCollection services)
	{
		services.AddTransient<IBookRepository, BookRepository>();
	}
}
