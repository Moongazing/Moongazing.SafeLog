namespace Moongazing.SafeLog.Exceptions.Types;

/// <summary>
/// Represents an exception for when a requested resource is not found.
/// </summary>

public class NotFoundException : Exception
{
    public NotFoundException() { }
    public NotFoundException(string? message) : base(message) { }
    public NotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
}