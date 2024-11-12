using Microsoft.AspNetCore.Diagnostics;

namespace webapi.core{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async  ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;
            if(exception is NotFoundException){
                problemDetails.Status = (int)StatusCodes.Status404NotFound;
            }else{
                problemDetails.Status = (int)StatusCodes.Status500InternalServerError;
            }
            httpContext.Response.StatusCode = problemDetails.Status;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}