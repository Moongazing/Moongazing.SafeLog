# Moongazing.SafeLog

Moongazing.SafeLog is a comprehensive exception handling and logging library designed for .NET applications. It centralizes exception management, provides robust logging capabilities using Serilog, and standardizes HTTP error responses.

---

## Features

- **Global Exception Handling**: Capture and handle exceptions across the application pipeline.
- **Custom Exception Types**: Includes predefined exceptions for validation, authorization, business rules, and more.
- **Serilog Integration**: Log exceptions and details to file, database, or other Serilog-supported sinks.
- **ProblemDetails Support**: Standardized error responses for HTTP APIs.
- **Extensibility**: Easily extend and customize exception handling and logging logic.

---

## Installation

1. Add the NuGet package:
   ```bash
   dotnet add package Moongazing.SafeLog

    Install Serilog and required sinks:

    dotnet add package Serilog
    dotnet add package Serilog.Sinks.File
    dotnet add package Serilog.Sinks.MSSqlServer

    Configure the middleware in your application.

Configuration
appsettings.json Example

{
  "SeriLogConfigurations": {
    "FileLogConfiguration": {
      "FolderPath": "logs/application",
      "FileSizeLimitBytes": 5000000
    },
    "MsSqlConfiguration": {
      "ConnectionString": "Server=localhost;Database=LogsDb;Trusted_Connection=True;",
      "TableName": "Logs",
      "AutoCreateSqlTable": true
    }
  }
}

Middleware Setup

Register the exception middleware in Program.cs:

using Moongazing.SafeLog.Exceptions.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();
app.Run();

Usage
Custom Exceptions

throw new ValidationException(new List<ValidationExceptionModel>
{
    new ValidationExceptionModel
    {
        Property = "Email",
        Errors = new[] { "Email cannot be empty.", "Email must be valid." }
    }
});

Logging Manually

var logger = new FileLogger(configuration);
logger.Info("This is an informational log.");

Handling HTTP ProblemDetails

ValidationException returns:

{
  "title": "Validation error(s)",
  "detail": "One or more validation errors occurred.",
  "status": 400,
  "type": "https://example.com/probs/validation",
  "errors": [
    {
      "property": "Email",
      "errors": [
        "Email cannot be empty.",
        "Email must be valid."
      ]
    }
  ]
}

Architecture
Exception Types
Exception Type	Description	HTTP Status
ValidationException	Used for validation errors.	400 Bad Request
NotFoundException	Thrown when a resource is not found.	404 Not Found
BusinessException	Thrown for business rule violations.	400 Bad Request
AuthorizationException	Thrown for authorization failures.	401 Unauthorized
Exception	General exceptions.	500 Internal Server Error
ProblemDetails

Predefined ProblemDetails classes for consistent HTTP error responses:

    ValidationProblemDetails
    NotFoundProblemDetails
    BusinessProblemDetails
    AuthorizationProblemDetails
    InternalServerErrorProblemDetails

Extending Functionality
Adding Custom Exceptions

    Create a new exception class inheriting from Exception.
    Override the appropriate HandleException method in HttpExceptionHandler.

Adding New Logging Sinks

    Create a new LoggerService class.
    Use Serilog to configure the new sink (e.g., Elasticsearch, Console).

Example:

public class ConsoleLogger : LoggerService
{
    public ConsoleLogger()
    {
        Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    }
}

License

This project is licensed under the MIT License - see the LICENSE file for details.
Contributing

We welcome contributions! Please fork the repository and submit a pull request with your improvements or bug fixes.
Contact

For questions or support, feel free to open an issue or contact the maintainer:

    Email: support@moongazing.dev
    GitHub: Moongazing

Changelog
v1.0.0

    Initial release with core exception handling and logging functionality.
    Added support for file and MSSQL logging.
    Standardized HTTP ProblemDetails integration.

