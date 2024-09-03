using System.Net;

namespace CurrencyConverter.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                var errodId = Guid.NewGuid();

                _logger.LogError(ex, $"{errodId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var error = new
                {
                    Id = errodId,
                    ErrorMessage = "Somehing went wrong! We are looking into resolving this issue"
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
