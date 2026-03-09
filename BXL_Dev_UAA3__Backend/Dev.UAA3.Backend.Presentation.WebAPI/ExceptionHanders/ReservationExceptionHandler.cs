using Dev.UAA3.Backend.Domain.BusinessExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dev.UAA3.Backend.Presentation.WebAPI.ExceptionHanders
{
    public class ReservationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ReservationException)
                return false;

            int statusCode;
            switch (exception)
            {
                case ReservationAlreadyExistsException:
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                case ReservationRoomNotAvalaibleException:
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                case ReservationNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                default:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
            }

            ProblemDetails problem = new ProblemDetails()
            {
                Title = "Reservation Exception",
                Detail = exception.Message,
                Status = statusCode
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
    }
}
