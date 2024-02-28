using TreeApp.Services;

namespace TreeApp.Web.Middleware
{
    public class SecureExceptionMiddleware : IMiddleware
    {
        private readonly IJournalWriterService _service;

        public SecureExceptionMiddleware(
            IJournalWriterService service)
        {
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (SecureException exception)
            {
                var requestId = DateTime.Now.Ticks.ToString();

                var text = $"RequestId = {requestId}\r\n" +
                    $"Path = {context.Request.Path}\r\n";

                var query = context.Request.Query;

                foreach (var queryPair in query)
                {
                    text += $"{queryPair.Key} = {queryPair.Value}\r\n";
                }

                text += exception.Message;

                var record = await _service.WriteRecordAsync(
                    requestId, text);


                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(record);
            }
        }
    }
}
