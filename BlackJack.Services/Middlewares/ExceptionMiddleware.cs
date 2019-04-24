using BlackJack.Services.Exceptions;
using BlackJack.ViewModels.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlackJack.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogDebug(exception.Message);
                if (exception.InnerException != null)
                {
                    _logger.LogDebug(exception.InnerException.Message);
                }
                ErrorViewModel error = new ErrorViewModel
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    StatusText = "Internal server error"
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)error.StatusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }
}
