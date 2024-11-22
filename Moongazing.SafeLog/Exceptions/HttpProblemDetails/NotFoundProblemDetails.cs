using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Moongazing.SafeLog.Exceptions.HttpProblemDetails;
/// <summary>
/// Provides a formatted response for 404 Not Found errors.
/// </summary>

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not found";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://example.com/probs/notfound";
    }
}

