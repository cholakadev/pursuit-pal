using PursuitPal.Core.Exceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Responses;
using System.Net;
using System.Text.Json;

namespace PursuitPal.Presentation.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

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
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var errorStatusCode = (error as HttpRequestException)?.StatusCode;

                response.StatusCode = (int?)errorStatusCode ?? error switch
                {
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    FailedAuthenticationException => StatusCodes.Status401Unauthorized,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    BaseException => (int)HttpStatusCode.InternalServerError,
                    _ => (int)HttpStatusCode.InternalServerError, // unhandled error
                };

                _logger.LogError(error, "Something went wrong");

                if (error is ValidationException e)
                {
                    var errorResponse = new ErrorResponse { ErrorMessage = e.Message };

                    await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                }
                else if (response.StatusCode == (int)HttpStatusCode.InternalServerError)
                {
                    await response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
                    {
                        ErrorMessage = "Internal Server Error",
                    }));
                }
            }
        }
    }
}
