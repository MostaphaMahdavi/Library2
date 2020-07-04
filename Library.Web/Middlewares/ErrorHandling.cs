using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Library.Web.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;
        public ErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = context.Response.StatusCode;
            var result = JsonConvert.SerializeObject(
                new
                {
                    source = ex.Source,
                    error = ex.Message
                });
            context.Response.ContentType = "application/json";


            Log.ForContext("Message", ex.Message)
                .Error($"Error: {result} StatusCode: {statusCode}");

            return context.Response.WriteAsync(result);
        }

    }
}
