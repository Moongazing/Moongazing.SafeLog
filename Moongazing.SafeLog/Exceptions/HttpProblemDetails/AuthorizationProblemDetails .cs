using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Moongazing.SafeLog.Exceptions.HttpProblemDetails;
/// <summary>
/// Provides a formatted response for authorization issues.
/// </summary>

public class AuthorizationProblemDetails : ProblemDetails
{
    public AuthorizationProblemDetails(string detail)
    {
        Title = "Authorization Problem";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://example.com/probs/business";
    }
}