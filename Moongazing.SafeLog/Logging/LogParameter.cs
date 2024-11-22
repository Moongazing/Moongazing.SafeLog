namespace Moongazing.SafeLog.Logging;

/// <summary>
/// Represents a log parameter that can be used to store detailed information
/// about a specific property or value being logged. 
/// This class is designed to capture the name, value, and type of the parameter.
/// </summary>
public class LogParameter
{
    /// <summary>
    /// Gets or sets the name of the log parameter.
    /// This typically represents the property or value being logged.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the log parameter.
    /// This is the actual data being logged.
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    /// Gets or sets the type of the log parameter.
    /// This represents the data type of the logged value (e.g., string, int).
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogParameter"/> class
    /// with default values. All properties are set to their default types:
    /// - Name: Empty string
    /// - Value: Empty string
    /// - Type: Empty string
    /// </summary>
    public LogParameter()
    {
        Name = string.Empty;
        Value = string.Empty;
        Type = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogParameter"/> class
    /// with the specified values for Name, Value, and Type.
    /// </summary>
    /// <param name="name">The name of the log parameter.</param>
    /// <param name="value">The value of the log parameter.</param>
    /// <param name="type">The type of the log parameter.</param>
    public LogParameter(string name, object value, string type)
    {
        Name = name;
        Value = value;
        Type = type;
    }
}
