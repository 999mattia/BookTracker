using System.Net;
using System.Text.Json;
using BookTracker.Core.Exceptions;

namespace BookTracker.Presentation.Middleware;

public class ExceptionMiddleware
{
	private RequestDelegate next { get; }

	public ExceptionMiddleware(RequestDelegate next)
	{
		this.next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var statusCode = HttpStatusCode.InternalServerError;
		var result = string.Empty;

		switch (exception)
		{
			case NotFoundException notFoundException:
				statusCode = HttpStatusCode.NotFound;
				result = JsonSerializer.Serialize(new { error = notFoundException.Message });
				break;

			default:
				result = JsonSerializer.Serialize(new { error = $"An unexpected error occurred: {exception.Message}" });
				break;
		}

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)statusCode;

		return context.Response.WriteAsync(result);
	}
}
