using BlackJack.Services.Exceptions;
using BlackJack.ViewModels.Error;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlackJack.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                ErrorViewModel error = null;

                if (exception is UserNotFoundException)
                {
                    error = new ErrorViewModel
                    {
                        StatusCode = HttpStatusCode.Conflict,
                        StatusText = exception.Message
                    };
                }

                if (error == null)
                {
                    error = new ErrorViewModel
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        StatusText = "Internal server error"
                    };
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)error.StatusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }
}
