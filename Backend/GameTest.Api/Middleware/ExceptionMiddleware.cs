using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace GameTest.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var (statusCode, message, errors) = ex switch
            {
                ValidationException validationEx => (
                    400,
                    "Validation failed",
                    validationEx.Errors.Select(e => new
                    {
                        field = e.PropertyName,
                        message = e.ErrorMessage
                    })
                ),

                AuthenticationException => (
                    401,
                    ex.Message,
                    null
                ),

                UnauthorizedAccessException => (
                    401,
                    ex.Message,
                    null
                ),

                KeyNotFoundException => (
                    404,
                    ex.Message,
                    null
                ),

                ArgumentException => (
                    400,
                    ex.Message,
                    null
                ),

                DbUpdateException => (
                    409,
                    "Database conflict",
                    null
                ),

                InvalidOperationException => (
                    400,
                    ex.Message,
                    null
                ),

                OperationCanceledException => (
                    499,
                    "Request cancelled",
                    null
                ),

                _ => (
                    500,
                    "Internal server error",
                    null
                )
            };

            context.Response.StatusCode = statusCode;

            var response = new
            {
                status = statusCode,
                message,
                errors
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}