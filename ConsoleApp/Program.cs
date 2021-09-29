using System;
using System.Linq;
using System.Threading;
using Bogus;
using ConsoleApp.Configurations;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static IConfigurationRoot ConfigRoot { get; }
        static ServiceProvider ServiceProvider {get;}

        static Program()
        {
            ConfigRoot = GetConfig();
            ServiceProvider = GetServiceProvider();
        }

        static IConfigurationRoot GetConfig()
        {
            //package Microsoft.Extensions.Configuration
            var config = new ConfigurationBuilder()

            //package Microsoft.Extensions.Configuration.FileExtensions
            //package Microsoft.Extensions.Configuration.Json
            .AddJsonFile("Configurations/config.json", true)
            //package Microsoft.Extensions.Configuration.Xml
            .AddXmlFile("Configurations/config.xml", true)
            //package Microsoft.Extensions.Configuration.Ini
            .AddIniFile("Configurations/config.ini", true)
            //package NetEscapades.Configuration.Yaml
            .AddYamlFile("Configurations/config.yaml", true)
            .Build();

            return config;
        }

        static void Main(string[] args)
        {

            //Console.WriteLine($"{ConfigRoot.GetSection("json").GetSection("SubSection")["SubSectionKey2"]} {person.LastName} {person.FirstName} {ConfigRoot.GetSection("json")["SectionKey1"]}!");
            //Console.WriteLine($"{Config.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {Config.Json.SectionKey1}!");
            var config = ServiceProvider.GetService<ConfigApp>();


            var people = ServiceProvider.GetService<IService<Models.Person>>().Read();
            var text = string.Join("\n", people.Select(person => $"{config.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {config.Json.SectionKey1}!"));

            //var person = new PersonFaker().Generate(1).Single();
            //var text = $"{config.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {config.Json.SectionKey1}!";



            //TestDependencyInjection(text);
            var service = ServiceProvider.GetService<ConsoleService>();
            service.WriteLine(text);
        }

        private static void TestDependencyInjection(string text)
        {
            //new FiggleConsoleService(new ConsoleService()).WriteLine(text);
            var service = ServiceProvider.GetService<FiggleConsoleService>();
            service.WriteLine(text);
            service = ServiceProvider.GetService<FiggleConsoleService>();
            service.WriteLine(text);
            var service2 = ServiceProvider.GetService<IConsoleService>();
            service2.WriteLine(text);
            service2 = ServiceProvider.GetService<IConsoleService>();
            service2.WriteLine(text);

            using (var scoped = ServiceProvider.CreateScope())
            {
                service = scoped.ServiceProvider.GetService<FiggleConsoleService>();
                service.WriteLine(text);
                service = scoped.ServiceProvider.GetService<FiggleConsoleService>();
                service.WriteLine(text);
                service = scoped.ServiceProvider.GetService<FiggleConsoleService>();
                service.WriteLine(text);
                service2 = scoped.ServiceProvider.GetService<IConsoleService>();
                service2.WriteLine(text);
                service2 = scoped.ServiceProvider.GetService<IConsoleService>();
                service2.WriteLine(text);
            }
            using (var scoped = ServiceProvider.CreateScope())
            {
                service = scoped.ServiceProvider.GetService<FiggleConsoleService>();
                service.WriteLine(text);
                service2 = scoped.ServiceProvider.GetService<IConsoleService>();
                service2.WriteLine(text);
            }

            foreach (var item in ServiceProvider.GetServices<IConsoleService>())
            {
                item.WriteLine(item.GetType().FullName);
            }
        }

        private static ServiceProvider GetServiceProvider()
        {

            var configApp = new ConfigApp();
            //package Microsoft.Extensions.Configuration.Binder
            ConfigRoot.Bind(configApp);

            //package Microsoft.Extensions.DependencyInjection
            var serviceCollection = new ServiceCollection();
            return serviceCollection.AddSingleton<ConsoleService>()
                            .AddSingleton(configApp)
                           .AddTransient<FiggleConsoleService>()
                           .AddScoped<IConsoleService, FiggleConsoleService>()
                           .AddScoped<IConsoleService, ConsoleService>()
                           
                           .AddSingleton<EntityFaker<Models.Person>, PersonFaker>()
                           .AddSingleton<IService<Models.Person>>(x => new Service<Models.Person>(x.GetService<EntityFaker<Models.Person>>(), x.GetService<ConfigApp>().Json.Values.Max()))
                           
                           .BuildServiceProvider();
        }
    }
}
