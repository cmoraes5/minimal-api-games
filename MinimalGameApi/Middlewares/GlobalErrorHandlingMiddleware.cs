using MinimalGameApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace MinimalGameApi.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string stackTrace = string.Empty;
            string message;

            switch (ex)
            {
                case NotFoundException:
                    message = ex.Message;
                    status = HttpStatusCode.NotFound;
                    stackTrace = ex.StackTrace;
                    break;

                case BadRequestException:
                    message = ex.Message;
                    status = HttpStatusCode.BadRequest;
                    stackTrace = ex.StackTrace;
                    break;

                default:
                    message = ex.Message;
                    status = HttpStatusCode.InternalServerError;
                    stackTrace = ex.StackTrace;
                    break;
            }

            var result = JsonSerializer.Serialize(new { status, message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
