using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
        private int count = 0;
        private const int LIMIT = 5;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (count >= LIMIT)
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            else
            {
                count++;
                try
                {
                    await next();
                }
                finally
                {
                    count--;
                }
            }
        }
    }
}
