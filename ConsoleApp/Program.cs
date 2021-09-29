using System;
using System.Linq;
using System.Threading;
using ConsoleApp.Configurations;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services.Bogus.Fakers;

namespace ConsoleApp
{
    class Program
    {
        static IConfigurationRoot ConfigRoot { get; }
        static ConfigApp Config { get; }
        static ServiceProvider ServiceProvider {get;}

        static Program()
        {
            Config = GetConfig(out var root);
            ConfigRoot = root;
            ServiceProvider = GetServiceProvider();
        }

        static ConfigApp GetConfig(out IConfigurationRoot root)
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
            var configApp = new ConfigApp();
            //package Microsoft.Extensions.Configuration.Binder
            config.Bind(configApp);

            root = config;
            return configApp;
        }

        static void Main(string[] args)
        {
            var person = new PersonFaker().Generate(1).Single();

            //Console.WriteLine($"{ConfigRoot.GetSection("json").GetSection("SubSection")["SubSectionKey2"]} {person.LastName} {person.FirstName} {ConfigRoot.GetSection("json")["SectionKey1"]}!");
            //Console.WriteLine($"{Config.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {Config.Json.SectionKey1}!");
            var text = $"{Config.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {Config.Json.SectionKey1}!";

            TestDependencyInjection(text);
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
            //package Microsoft.Extensions.DependencyInjection
            var serviceCollection = new ServiceCollection();
            return serviceCollection.AddSingleton<ConsoleService>()
                           .AddTransient<FiggleConsoleService>()
                           .AddScoped<IConsoleService, FiggleConsoleService>()
                           .AddScoped<IConsoleService, ConsoleService>()
                           .BuildServiceProvider();
        }
    }
}
