using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Api.Filters
{
    public class InvalidOperationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            InvalidOperationException invalidOperationException = context.Exception as InvalidOperationException;

            if (invalidOperationException != null)
            {
                string json = JsonConvert.SerializeObject("Erro de input.");

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
