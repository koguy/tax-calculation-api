using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using TaxCalculatorApi.Dtos;

namespace TaxCalculatorApi.ExceptionHandlers
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception.Message);

            HttpResponse response = httpContext.Response;
            response.StatusCode = StatusCodes.Status500InternalServerError;

            ErrorDto errorDto = new ErrorDto()
            {
                Message = "Internal Server Error",
                StatusCode = StatusCodes.Status500InternalServerError
            };

            string result = JsonSerializer.Serialize(errorDto);
            await response.WriteAsJsonAsync(result, cancellationToken);

            return true;
        }
    }
}
