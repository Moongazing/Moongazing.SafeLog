namespace Moongazing.SafeLog.Exceptions.Types;
/// <summary>
/// Represents an exception for authorization-related issues.
/// </summary>

public class AuthorizationException : Exception
{
    public AuthorizationException() { }

    public AuthorizationException(string? message) : base(message) { }

    public AuthorizationException(string? message, Exception? innerException) : base(message, innerException) { }
}
