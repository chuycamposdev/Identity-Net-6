using System.Net;
using System.Text.Json;
using Tickets.Application.Exceptions;
using Tickets.Application.Models;

namespace API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var operationResult =  OperationResult.Error(exception?.Message);
            switch (exception)
            {
                case ApiException e:
                    break;
                case NotFoundException ex:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ValidationException ex:
                    operationResult.Errors = ex.Errors;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(operationResult);
            await context.Response.WriteAsync(result);
        }
    }
}
