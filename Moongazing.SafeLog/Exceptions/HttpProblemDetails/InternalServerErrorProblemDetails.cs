using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Moongazing.SafeLog.Exceptions.HttpProblemDetails;
/// <summary>
/// Provides a formatted response for internal server errors.
/// </summary>

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(string detail)
    {
        Title = "Internal Server Error";
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://example.com/probs/internal";
    }
}