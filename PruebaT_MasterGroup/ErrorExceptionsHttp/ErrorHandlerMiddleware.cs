using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.ErrorExceptionsHttp
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int code;
            if (ex is ArgumentException)
                code = StatusCodes.Status400BadRequest;
            else if (ex is UnauthorizedAccessException)
                code = StatusCodes.Status401Unauthorized;
            else if (ex is KeyNotFoundException)
                code = StatusCodes.Status404NotFound;
            else
                code = StatusCodes.Status500InternalServerError;

            var result = JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
