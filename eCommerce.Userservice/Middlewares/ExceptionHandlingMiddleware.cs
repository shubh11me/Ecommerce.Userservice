namespace Ecommerce.Userservice.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError("Error: " + ex.Message + " type:" + ex.GetType().ToString());
                if(ex.InnerException != null)
                {
                    logger.LogError("Error: " + ex.InnerException.Message + " type:" + ex.InnerException.GetType().ToString());
                }
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new {message= ex.Message, type= ex.GetType().ToString() });
            } 
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
