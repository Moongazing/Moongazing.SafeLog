using Microsoft.AspNetCore.Http;
using Moongazing.SafeLog.Exceptions.Handlers;
using Moongazing.SafeLog.Logging;
using System.Net.Mime;
using System.Text.Json;

namespace Moongazing.SafeLog.Exceptions;

/// <summary>
/// Middleware responsible for globally handling exceptions in the application.
/// Captures exceptions, logs their details, and provides a consistent response to clients.
/// </summary>
public class ExceptionMiddleware
{
    /// <summary>
    /// Provides access to the current HTTP context.
    /// </summary>
    private readonly IHttpContextAccessor contextAccessor;

    /// <summary>
    /// Handles HTTP exceptions and formats appropriate responses.
    /// </summary>
    private readonly HttpExceptionHandler httpExceptionHandler = new();

    /// <summary>
    /// Logger service used to log exception details.
    /// </summary>
    private readonly LoggerService loggerService;

    /// <summary>
    /// The next middleware in the request pipeline.
    /// </summary>
    private readonly RequestDelegate next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the request pipeline.</param>
    /// <param name="contextAccessor">Provides access to the current HTTP context.</param>
    /// <param name="loggerService">The logger service for logging exceptions.</param>
    public ExceptionMiddleware(RequestDelegate next,
                               IHttpContextAccessor contextAccessor,
                               LoggerService loggerService)
    {
        this.contextAccessor = contextAccessor;
        this.loggerService = loggerService;
        this.next = next;
    }

    /// <summary>
    /// Middleware invocation method that processes incoming requests.
    /// Captures and handles any exceptions thrown during the request pipeline execution.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    /// <returns>A task representing the middleware execution.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);  // Log exception details
            await HandleExceptionAsync(context.Response, exception);  // Handle exception response
        }
    }

    /// <summary>
    /// Logs the details of the exception.
    /// </summary>
    /// <param name="context">The HTTP context associated with the exception.</param>
    /// <param name="exception">The exception to log.</param>
    /// <returns>A completed task.</returns>
    protected virtual Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter
            {
                Type = context.GetType().Name,
                Value = exception.ToString()
            }
        };

        LogDetail logDetail = new()
        {
            MethodName = next.Method.Name,
            Parameters = logParameters,
            User = contextAccessor.HttpContext?.User.Identity?.Name ?? "?"
        };

        loggerService.Info(JsonSerializer.Serialize(logDetail));
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles the exception and formats the HTTP response.
    /// </summary>
    /// <param name="response">The HTTP response to be sent to the client.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <returns>A task representing the exception handling process.</returns>
    protected virtual Task HandleExceptionAsync(HttpResponse response, dynamic exception)
    {
        response.ContentType = MediaTypeNames.Application.Json;
        httpExceptionHandler.Response = response;

        return httpExceptionHandler.HandleException(exception);
    }
}
