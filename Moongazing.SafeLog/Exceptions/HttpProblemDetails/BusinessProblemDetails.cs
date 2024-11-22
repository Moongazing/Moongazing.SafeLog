using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Moongazing.SafeLog.Exceptions.HttpProblemDetails;
/// <summary>
/// Provides a formatted response for business rule violations.
/// </summary>

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Rule Violation";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/business";
    }
}