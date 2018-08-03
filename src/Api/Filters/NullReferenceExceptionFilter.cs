using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Filters
{
    public class NullReferenceExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            NullReferenceException nullReferenceException = context.Exception as NullReferenceException;
            if (nullReferenceException != null)
            {
                string json = JsonConvert.SerializeObject("Erro interno da aplicação.");

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
