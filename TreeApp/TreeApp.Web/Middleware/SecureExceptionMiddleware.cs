using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;
using TreeApp.Services;
using TreeApp.Web.ViewModels;

namespace TreeApp.Web.Middleware
{
    public class SecureExceptionMiddleware : IMiddleware
    {
        private readonly IJournalWriterService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SecureExceptionMiddleware(
            IJournalWriterService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

                await context.Response.WriteAsJsonAsync(
                    _mapper.Map<JournalRecordVM>(record));
            }
        }
    }
}
