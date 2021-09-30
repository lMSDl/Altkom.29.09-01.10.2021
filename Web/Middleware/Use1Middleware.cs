using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class Use1Middleware
    {
        private RequestDelegate _next;

        public Use1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Begin Use1");
            await _next(context);
            Console.WriteLine("End Use1");
        }
    }
}
