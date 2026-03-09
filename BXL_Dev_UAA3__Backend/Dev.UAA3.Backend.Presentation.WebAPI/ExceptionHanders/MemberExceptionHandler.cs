using Dev.UAA3.Backend.Domain.BusinessExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dev.UAA3.Backend.Presentation.WebAPI.ExceptionHanders
{
    public class MemberExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not MemberException)
                return false;

            int statusCode;
            switch (exception)
            {
                case MemberBadCredentialException:
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    break;
                case MemberAlreadyExistsException:
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                default:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
            }

            ProblemDetails problem = new ProblemDetails()
            {
                Title = "Member Exception",
                Detail = exception.Message,
                Status = statusCode
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
    }
}
