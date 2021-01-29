using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Autak.API.Middlewares
{
	public class RequestLoggingMiddleware
	{
		private readonly ILogger logger;
		private readonly RequestDelegate next;

		public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
		{
			this.next = next;
			this.logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await next(context);
			}
			finally
			{
				logger.LogInformation(
					"Request {method} {url} => {statusCode}",
					context.Request?.Method,
					context.Request?.Path.Value,
					context.Response?.StatusCode);
			}
		}
	}
}