using IceGestor.Application.Models.ViewModels.Exception;
using IceGestor.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace IceGestor.Api.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is IceGestorException)
            HandleIceGestorException(context);
        else
            ThrowUnknownError(context);
    }
    private static void HandleIceGestorException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsException)
            HandleValidationErrorsException(context);
    }

    private static void HandleValidationErrorsException(ExceptionContext context)
    {
        var validationErrorException = context.Exception as ValidationErrorsException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ResponseErrorViewModel(validationErrorException.ErrorMessages));
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorViewModel("Erro Desconhecido"));
    }
}
