using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Authentication;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            InvalidOperationExceptionMessage(exception, ref message);
            DatabaseExceptionMessage(exception, ref message);
            SystemAuthenticationExceptionMessage(ref message, exception);
            return httpContext.Response.WriteAsync(new ErrorDetail
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }


        private void InvalidOperationExceptionMessage(Exception exception, ref string message)
        {
            if (exception.GetType() != typeof(InvalidOperationException))
                return;

            if (!string.IsNullOrEmpty(exception.Message))
            {
                message = exception.Message;
                return;
            }

        

        }
        private void DatabaseExceptionMessage(Exception exception, ref string message)
        {
            if (exception.GetType() != typeof(DbUpdateException))
                return;

            if (!string.IsNullOrEmpty(exception.InnerException.Message))
            {
                message = exception.InnerException.Message;
                return;
            }

            if (!string.IsNullOrEmpty(exception.Message))
            {
                message = exception.Message;
                return;
            }

        }
        private void SystemAuthenticationExceptionMessage(ref string message, Exception exception)
        {
            if (exception.GetType() != typeof(AuthenticationException))
                return;

            if (!string.IsNullOrEmpty(exception.InnerException.Message))
            {
                message = exception.InnerException.Message;
                return;
            }

            if (!string.IsNullOrEmpty(exception.Message))
            {
                message = exception.Message;
                return;
            }

        }
    }
}
