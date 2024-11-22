namespace Moongazing.SafeLog.Exceptions.Types;
/// <summary>
/// Represents an exception type for validation errors. Contains detailed information 
/// about validation issues, including the invalid property and associated errors.
/// </summary>

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException() : base()
    {
        Errors = [];
    }

    public ValidationException(string? message) : base(message)
    {
        Errors = [];
    }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        IEnumerable<string> arr = errors.Select(x => $"{Environment.NewLine} -- {x.Property}: {string.Join(Environment.NewLine, values: x.Errors ?? [])}");

        return $"Validation failed: {string.Join(string.Empty, arr)}";
    }
}
/// <summary>
/// Represents a validation error detail, including the property name 
/// and a list of error messages associated with it.
/// </summary>

public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}