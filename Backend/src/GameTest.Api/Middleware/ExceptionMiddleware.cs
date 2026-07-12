using FluentValidation;
using GameTest.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

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
                    StatusCodes.Status400BadRequest,
                    "Validation failed",
                    validationEx.Errors.Select(e => new
                    {
                        field = e.PropertyName,
                        message = e.ErrorMessage
                    })
                ),

                DomainException => (
                    StatusCodes.Status400BadRequest,
                    ex.Message,
                    null
                ),

                UnauthorizedException => (
                    StatusCodes.Status401Unauthorized,
                    ex.Message,
                    null
                ),

                NotFoundException => (
                    StatusCodes.Status404NotFound,
                    ex.Message,
                    null
                ),

                ConflictException => (
                    StatusCodes.Status409Conflict,
                    ex.Message,
                    null
                ),

                DbUpdateException => (
                    StatusCodes.Status409Conflict,
                    "Database conflict.",
                    null
                ),

                OperationCanceledException => (
                    499,
                    "Request cancelled.",
                    null
                ),

                _ => (
                    StatusCodes.Status500InternalServerError,
                    "Internal server error.",
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