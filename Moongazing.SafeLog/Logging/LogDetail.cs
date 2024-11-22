using Moongazing.SafeLog.Logging;

namespace Moongazing.SafeLog.Logging;

/// <summary>
/// Represents the detailed log information for a specific operation or method execution.
/// Provides contextual information such as the class and method names, the user involved,
/// and any associated parameters.
/// </summary>
public class LogDetail
{
    /// <summary>
    /// Gets or sets the full name of the class or namespace where the logged method resides.
    /// Typically includes the namespace and class name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Gets or sets the name of the method being logged.
    /// </summary>
    public string MethodName { get; set; }

    /// <summary>
    /// Gets or sets the user or account associated with the log entry.
    /// This provides information about the entity performing the operation.
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// Gets or sets the list of parameters passed to the logged method.
    /// Each parameter includes its name, value, and type.
    /// </summary>
    public List<LogParameter> Parameters { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogDetail"/> class with default values.
    /// All string properties are initialized to empty strings, and <see cref="Parameters"/> is initialized to an empty list.
    /// </summary>
    public LogDetail()
    {
        FullName = string.Empty;
        MethodName = string.Empty;
        User = string.Empty;
        Parameters = new List<LogParameter>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogDetail"/> class with specified details.
    /// </summary>
    /// <param name="fullName">The full name of the class or namespace being logged.</param>
    /// <param name="methodName">The name of the method being logged.</param>
    /// <param name="user">The user or account associated with the log entry.</param>
    /// <param name="parameters">The list of parameters passed to the method being logged.</param>
    public LogDetail(string fullName, string methodName, string user, List<LogParameter> parameters)
    {
        FullName = fullName;
        MethodName = methodName;
        User = user;
        Parameters = parameters;
    }
}
