namespace EventManageApp.Core.Common
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
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
            catch (Exception ex)
            {

                _logger.LogError(ex, "An unhandled exception has occurred.");

                // Store the error message in TempData
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError; // 500
                context.Response.ContentType = "text/html";

                // Use TempData to store the error message
                context.Items["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                context.Response.Redirect(context.Request.Path);
            }
        }
    }
}