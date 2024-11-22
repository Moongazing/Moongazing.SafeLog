using Microsoft.Extensions.Configuration;
using Moongazing.SafeLog.Logging;
using Moongazing.SafeLog.Logging.SeriLog.ConfigurationModels;
using Moongazing.SafeLog.Logging.SeriLog.Messages;
using Serilog;

namespace Moongazing.SafeLog.Logging.SeriLog.Logger;

/// <summary>
/// A logger implementation that writes log messages to a file using Serilog.
/// The log configuration, such as the file path and log options, is dynamically loaded
/// from the application's configuration file (e.g., appsettings.json).
/// </summary>
public class FileLogger : LoggerService
{
    /// <summary>
    /// The application configuration instance for retrieving logging settings.
    /// </summary>
    private readonly IConfiguration configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLogger"/> class.
    /// Configures a Serilog file sink based on settings from the application's configuration file.
    /// </summary>
    /// <param name="configuration">
    /// An instance of <see cref="IConfiguration"/> used to access SeriLog's file logging configuration.
    /// </param>
    /// <exception cref="Exception">
    /// Thrown if the file logging configuration is missing or incomplete.
    /// </exception>
    public FileLogger(IConfiguration configuration)
    {
        this.configuration = configuration;

        // Retrieve file logging configuration from the configuration file
        FileLogConfiguration logConfig =
            configuration.GetSection("SeriLogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        // Construct the log file path based on the current directory and folder path configuration
        string logFilePath = string.Format(format: "{0}{1}",
            arg0: Directory.GetCurrentDirectory() + "." + logConfig.FolderPath,
            arg1: ".txt");

        // Configure Serilog to write logs to the specified file
        Logger = new LoggerConfiguration().WriteTo.File(
            logFilePath,
            rollingInterval: RollingInterval.Day,  // Creates a new log file for each day
            retainedFileCountLimit: null,          // No limit on retained log files
            fileSizeLimitBytes: 5000000,           // Maximum file size of 5 MB
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}" // Custom log format
            ).CreateLogger();
    }
}
