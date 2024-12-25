using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Serilog;
using ShipmentTracker.Application;
using ShipmentTracker.Application.Exceptions;
using System.Net;
using System.Numerics;

namespace ShipmentTracker.API.Core
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception exception)
            {
                var date = DateTime.UtcNow;
                var username = context.User?.Identity?.Name ?? "Unknown";
                var requestPath = context.Request.Path.ToString();
                var requestMethod = context.Request.Method;

                if (exception is UnauthorizedAccessException)
                {
                    context.Response.StatusCode = 401;
                    _logger.LogError($"{date}, User:{username}, Path: {requestPath}, Method: {requestMethod}");
                    return;
                }

                if (exception is ValidationException ex)
                {
                    context.Response.StatusCode = 400;
                    var body = ex.Errors.Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage });
                    var data = JsonConvert.SerializeObject(body);

                    await context.Response.WriteAsJsonAsync(body);
                    _logger.LogError($"{date}, User:{username}, Path: {requestPath}, Method: {requestMethod}, Errors: {data}");
                    return;
                }
                if (exception is NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsJsonAsync(exception.Message);
                    _logger.LogError($"{date}, User:{username}, Path: {requestPath}, Method: {requestMethod}, Message: {exception.Message}");
                    return;
                }

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { Message = $"An unexpected error has occured. Detailed message: " + $"{exception.Message}" });
            }
        }
    }
}
