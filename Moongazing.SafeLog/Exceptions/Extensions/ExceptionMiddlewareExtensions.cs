using Microsoft.AspNetCore.Builder;

namespace Moongazing.SafeLog.Exceptions.Extensions;
/// <summary>
/// Provides extension methods for configuring the custom exception middleware.
/// </summary>

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
