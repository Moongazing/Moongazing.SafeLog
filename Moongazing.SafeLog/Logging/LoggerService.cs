using Serilog;

namespace Moongazing.SafeLog.Logging;

/// <summary>
/// An abstract base class that provides a unified interface for logging
/// messages at various severity levels using the Serilog library.
/// This class can be extended to implement specific logging mechanisms
/// (e.g., logging to a database, file, or other sinks).
/// </summary>
public abstract class LoggerService
{
    /// <summary>
    /// Gets or sets the Serilog <see cref="ILogger"/> instance used for logging.
    /// This logger is responsible for handling log messages based on its configuration.
    /// </summary>
    public ILogger Logger { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerService"/> class with no logger.
    /// The <see cref="Logger"/> property must be initialized before using the logging methods.
    /// </summary>
    public LoggerService()
    {
        Logger = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerService"/> class with the specified logger.
    /// </summary>
    /// <param name="logger">The Serilog <see cref="ILogger"/> instance to be used for logging.</param>
    public LoggerService(ILogger logger)
    {
        Logger = logger;
    }

    /// <summary>
    /// Logs a verbose-level message, typically used for detailed debugging information.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Verbose(string message) => Logger.Verbose(message);

    /// <summary>
    /// Logs a fatal-level message, typically used for critical errors that cause the application to fail.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Fatal(string message) => Logger.Fatal(message);

    /// <summary>
    /// Logs an informational message, typically used for general application events.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Info(string message) => Logger.Information(message);

    /// <summary>
    /// Logs a warning message, typically used for potential issues that do not cause immediate errors.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Warn(string message) => Logger.Warning(message);

    /// <summary>
    /// Logs a debug-level message, typically used for diagnostic purposes during development.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Debug(string message) => Logger.Debug(message);

    /// <summary>
    /// Logs an error-level message, typically used for exceptions or unexpected errors.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Error(string message) => Logger.Error(message);
}
