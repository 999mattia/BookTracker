using BookTracker.Infrastructure.Contracts.Database;
using BookTracker.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Infrastructure.Extensions;

public static class DataContextExtensions
{
	public static void AddDataContext(this IServiceCollection services)
	{
		services.AddScoped<IDataContext, DataContext>();
	}
}
