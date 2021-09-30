using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class RunMiddleware
    {
        public RunMiddleware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Begin Run");
            await context.Response.WriteAsync("Hello from Run");
            Console.WriteLine("End Run");
        }
    }
}
