using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Middleware;

namespace Web
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Use2Middleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<Use1Middleware>();
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Begin Use1");
            //    await next();
            //    Console.WriteLine("End Use1");
            //});

            app.MapWhen(context => context.Request.Query.TryGetValue("Map", out var result) ? result == "true" : false, MapToMap);
            app.Map("/hello", MapToHello);


            //Use2ApplicationBuilderExtension.Use2Middleware(app);
            app.Use2Middleware();

            //app.UseMiddleware<Use2Middleware>();
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Begin Use2");
            //    await next();
            //    Console.WriteLine("End Use2");
            //});

            app.UseMiddleware<RunMiddleware>();
           // app.Run(async context =>
           //{
           //    Console.WriteLine("Begin Run");

           //    await context.Response.WriteAsync("Hello from Run");

           //    Console.WriteLine("End Run");

           //});
        }

        private static void MapToHello(IApplicationBuilder mapApp)
        {
            mapApp.Run(async context =>
            {
                Console.WriteLine("Begin HelloRun");
                await context.Response.WriteAsync("Hello from HelloRun");
                Console.WriteLine("End HelloRun");

            });
        }

        private static void MapToMap(IApplicationBuilder mapApp)
        {
            mapApp.Map("/hello", MapToHello);

            mapApp.Use(async (context, next) =>
            {
                Console.WriteLine("Begin MapUse1");
                await next();
                Console.WriteLine("End MapUse1");
            });

            mapApp.Use(async (context, next) =>
            {
                Console.WriteLine("Begin MapUse2");
                await next();
                Console.WriteLine("End MapUse2");
            });

            mapApp.Run(async context =>
            {
                Console.WriteLine("Begin MapRun");
                await context.Response.WriteAsync("Hello from MapRun");
                Console.WriteLine("End MapRun");

            });

            mapApp.Use(async (context, next) =>
            {
                Console.WriteLine("Begin MapUse3");
                await next();
                Console.WriteLine("End MapUse3");
            });
        }
    }
}
