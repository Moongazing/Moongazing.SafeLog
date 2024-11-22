using Moongazing.SafeLog.Exceptions.Types;

namespace Moongazing.SafeLog.Exceptions.Handlers;
/// <summary>
/// Defines an abstract base class for exception handling with different exception types.
/// </summary>

public abstract class ExceptionHandler
{
    public abstract Task HandleException(BusinessException businessException);
    public abstract Task HandleException(ValidationException validationException);
    public abstract Task HandleException(AuthorizationException authorizationException);
    public abstract Task HandleException(NotFoundException notFoundException);
    public abstract Task HandleException(Exception exception);
}
