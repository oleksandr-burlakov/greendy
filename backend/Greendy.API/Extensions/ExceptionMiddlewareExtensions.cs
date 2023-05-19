using System.Net;
using Microsoft.AspNetCore.Diagnostics;
namespace Greendy.API;
public static class ExceptionMiddlewareExtensions
{
	public static void ConfiugureExceptionHandler(this IApplicationBuilder app)
	{
		app.UseExceptionHandler(appError => 
			{
				appError.Run(async context => 
					{
						context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						context.Response.ContentType = "application/json";

						var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
						if (contextFeature != null)
						{
							System.Console.WriteLine(contextFeature.Error);
							await context.Response.WriteAsync(new ErrorDetails() 
								{
									StatusCode = context.Response.StatusCode,
									Message = contextFeature?.Error.Message ?? "Internal server error"
								}.ToString());
						}
					});
			});
	}
}
