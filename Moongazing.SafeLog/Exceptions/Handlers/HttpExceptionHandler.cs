using Microsoft.AspNetCore.Http;
using Moongazing.SafeLog.Exceptions.Extensions;
using Moongazing.SafeLog.Exceptions.HttpProblemDetails;
using Moongazing.SafeLog.Exceptions.Types;

namespace Moongazing.SafeLog.Exceptions.Handlers;
/// <summary>
/// Handles specific exception types and maps them to appropriate HTTP responses
/// using custom problem details classes.
/// </summary>

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse Response
    {
        get => _response ?? throw new NullReferenceException(nameof(_response));
        set => _response = value;
    }

    private HttpResponse? _response;
    /// <summary>
    /// Handles business rule violations and returns a 400 Bad Request response.
    /// </summary>

    public override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).ToJson();
        return Response.WriteAsync(details);
    }
    /// <summary>
    /// Handles validation errors and returns a 400 Bad Request response with details.
    /// </summary>

    public override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new ValidationProblemDetails(validationException.Errors).ToJson();
        return Response.WriteAsync(details);
    }
    /// <summary>
    /// Handles authorization issues and returns a 401 Unauthorized response.
    /// </summary>

    public override Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        string details = new AuthorizationProblemDetails(authorizationException.Message).ToJson();
        return Response.WriteAsync(details);
    }
    /// <summary>
    /// Handles resource not found errors and returns a 404 Not Found response.
    /// </summary>

    public override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        string details = new NotFoundProblemDetails(notFoundException.Message).ToJson();
        return Response.WriteAsync(details);
    }
    /// <summary>
    /// Handles general exceptions and returns a 500 Internal Server Error response.
    /// </summary>

    public override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).ToJson();
        return Response.WriteAsync(details);
    }
}