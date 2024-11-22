using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Moongazing.SafeLog.Exceptions.Extensions;
/// <summary>
/// Provides extension methods for serializing ProblemDetails to JSON format.
/// </summary>

public static class ProblemDetailsExtensions
{
    public static string ToJson<TProblemDetail>(this TProblemDetail details)
       where TProblemDetail : ProblemDetails
    {
        return JsonSerializer.Serialize(details);
    }
}