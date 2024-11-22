using Doing.Retail.Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Moongazing.SafeLog.Logging.SeriLog.ConfigurationModels;
using Moongazing.SafeLog.Logging.SeriLog.Messages;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Moongazing.SafeLog.Logging.SeriLog.Logger;

/// <summary>
/// A logger implementation that writes log messages to a Microsoft SQL Server database
/// using Serilog. The configuration for this logger, including connection string and table
/// options, is dynamically loaded from the application's configuration file.
/// </summary>
public class MsSqlLogger : LoggerService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MsSqlLogger"/> class.
    /// Configures a Serilog MSSQL logger based on the provided application configuration.
    /// </summary>
    /// <param name="configuration">
    /// An instance of <see cref="IConfiguration"/> used to retrieve the MSSQL logging settings.
    /// </param>
    /// <exception cref="Exception">
    /// Thrown if the configuration section for MSSQL logging is missing or null.
    /// </exception>
    public MsSqlLogger(IConfiguration configuration)
    {
        // Retrieve MSSQL-specific Serilog configuration from the app configuration
        MsSqlConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        // Define MSSQL sink options, such as table name and auto-create behavior
        MSSqlServerSinkOptions sinkOptions = new()
        {
            TableName = logConfiguration.TableName,
            AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable
        };

        // Configure column options for MSSQL table structure
        ColumnOptions columnOptions = new();

        // Build Serilog configuration and set the logger
        Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(
                connectionString: logConfiguration.ConnectionString,
                sinkOptions: sinkOptions,
                columnOptions: columnOptions)
            .CreateLogger();

        Logger = seriLogConfig;
    }
}
