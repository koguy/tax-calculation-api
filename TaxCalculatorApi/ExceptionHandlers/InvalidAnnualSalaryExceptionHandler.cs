using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using TaxCalculatorApi.Dtos;
using TaxCalculatorApi.Exceptions;

namespace TaxCalculatorApi.ExceptionHandlers
{
    public class InvalidAnnualSalaryExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is InvalidAnnualSalaryException)
            {
                logger.LogError(exception.Message);

                HttpResponse response = httpContext.Response;
                response.StatusCode = StatusCodes.Status400BadRequest;

                ErrorDto errorDto = new ErrorDto()
                {
                    Message = "Bad Request",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                string result = JsonSerializer.Serialize(errorDto);
                await response.WriteAsJsonAsync(result, cancellationToken);

                return true;
            }
            return false;
        }
    }
}
