using Moongazing.SafeLog.Logging;

namespace Moongazing.SafeLog.Logging;

/// <summary>
/// Represents detailed log information with additional exception details.
/// Inherits from <see cref="LogDetail"/> to include common log properties
/// and extends it by adding a property for the exception message.
/// </summary>
public class LogDetailWithException : LogDetail
{
    /// <summary>
    /// Gets or sets the exception message associated with the log entry.
    /// This provides additional context for errors or exceptions being logged.
    /// </summary>
    public string ExceptionMessage { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogDetailWithException"/> class
    /// with default values. The <see cref="ExceptionMessage"/> is initialized as an empty string.
    /// </summary>
    public LogDetailWithException()
    {
        ExceptionMessage = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogDetailWithException"/> class
    /// with the specified details and exception message.
    /// </summary>
    /// <param name="fullName">The full name (namespace and class name) of the method being logged.</param>
    /// <param name="methodName">The name of the method being logged.</param>
    /// <param name="user">The user or account associated with the log entry.</param>
    /// <param name="parameters">The list of parameters related to the method being logged.</param>
    /// <param name="exceptionMessage">The exception message associated with the log entry.</param>
    public LogDetailWithException(
        string fullName,
        string methodName,
        string user,
        List<LogParameter> parameters,
        string exceptionMessage) : base(fullName, methodName, user, parameters)
    {
        ExceptionMessage = exceptionMessage;
    }
}
