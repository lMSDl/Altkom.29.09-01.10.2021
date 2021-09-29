using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class HostProgram
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config =>
                {
                    config.AddJsonFile("Configurations/config.json");
                })
                .ConfigureServices((context, services) =>
                {
                    services
                    .AddSingleton<EntityFaker<Models.Person>, PersonFaker>()
                    .AddSingleton<IService<Models.Person>, Service<Models.Person>>()

                    .AddHostedService<MainService>();
                })

                .Build()
                .Run();
        }
    }
}
