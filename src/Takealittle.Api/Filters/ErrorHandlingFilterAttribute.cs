﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Takealittle.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.." ,
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = context.Exception.StackTrace
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}