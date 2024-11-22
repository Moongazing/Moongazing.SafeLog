namespace Moongazing.SafeLog.Exceptions.Types;
/// <summary>
/// Represents an exception type for business rule violations.
/// </summary>

public class BusinessException : Exception
{
    public BusinessException() { }
    public BusinessException(string? message) : base(message) { }

    public BusinessException(string? message, Exception? innerException) : base(message, innerException) { }

}
