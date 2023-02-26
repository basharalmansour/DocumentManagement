using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.WebUI.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{

    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        // Register known exception types and handlers.
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                {typeof(BadRequestException),HandleBadRequestException },
                {typeof(ConflictException),HandleConflictException }
            };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }
 
        HandleUnknownException(context);
    }
    private void HandleConflictException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status409Conflict);
    }
    private void HandleValidationException(ExceptionContext context)
    {
        var validationException = (ValidationException)context.Exception;
        var errorResponse = new ErrorResponseModel()
        {
            Message = validationException.Errors.FirstOrDefault().Value.FirstOrDefault(),
        };
        context.Result = new ObjectResult(errorResponse);
        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
    
    private void HandleInvalidModelStateException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status400BadRequest);
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status404NotFound);
    }
    private void HandleBadRequestException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status400BadRequest);
    }
    private void HandleUnauthorizedAccessException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status401Unauthorized);
    }

    private void HandleForbiddenAccessException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status403Forbidden);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        HandleUIExceptions(context, StatusCodes.Status500InternalServerError);
    }
    private void HandleUIExceptions(ExceptionContext context, int statusCode)
    {
        var errorResponse = new ErrorResponseModel()
        {
            Message = StatusCodes.Status500InternalServerError != statusCode ? context.Exception.Message : "Internal server error!",
        };
        context.Result = new ObjectResult(errorResponse);
        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = statusCode;
    }
}
