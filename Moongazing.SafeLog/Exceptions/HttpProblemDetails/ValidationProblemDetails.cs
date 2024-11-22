using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moongazing.SafeLog.Exceptions.Types;

namespace Moongazing.SafeLog.Exceptions.HttpProblemDetails;
/// <summary>
/// Provides detailed information about validation errors to be sent in HTTP responses.
/// </summary>

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors occurred.";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation";
    }
}