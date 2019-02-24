﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace Backfy.Api.Filters
{
    /// <summary>
    /// Exception filter to machine-readable format for specifying errors in HTTP API responses based on  https://tools.ietf.org/html/rfc7807.
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Overriges of base implementation of exception filter
        /// </summary>
        /// <param name="context">The context of exception</param>
        public override void OnException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{400}",
                Title = ReasonPhrases.GetReasonPhrase(400),
                Detail = context.Exception.Message,
                Instance = "about:blank",
                Status = 400
            };

            context.ExceptionHandled = true;    
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = 400,
                DeclaredType = context.Exception.GetType()
            };
        }
    }
}
