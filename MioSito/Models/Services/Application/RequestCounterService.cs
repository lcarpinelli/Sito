using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MioSito.Models.Services.Application
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestCounterService
    {
        private readonly RequestDelegate _next;
        private int count = 0;

        public RequestCounterService(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext httpContext)
        {
                Interlocked.Increment(ref count);
                await _next(httpContext);
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestCounterServiceExtensions
    {
        public static IApplicationBuilder UseRequestCounterService(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCounterService>();
        }
    }
}
