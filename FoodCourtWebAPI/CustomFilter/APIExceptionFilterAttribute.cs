using FoodCourtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace FoodCourtWebAPI.CustomFilter
{
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
            WebAPIResult errorResult = new WebAPIResult() { result = context.Exception.Message + context.Exception.StackTrace, bSucessfulOperation = false };
            context.Response = context.Request.CreateResponse(HttpStatusCode.NotImplemented, errorResult);
        }

    }
}