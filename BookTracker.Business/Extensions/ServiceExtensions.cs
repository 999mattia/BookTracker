using BookTracker.Business.Contracts.Services;
using BookTracker.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Business.Extensions;

public static class ServiceExtensions
{
	public static void AddServices(this IServiceCollection services)
	{
		services.AddTransient<IBookService, BookService>();
	}
}
