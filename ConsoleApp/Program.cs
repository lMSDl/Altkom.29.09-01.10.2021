using System;
using System.Linq;
using System.Threading;
using ConsoleApp.Configurations;
using Microsoft.Extensions.Configuration;
using Models;
using Services.Bogus.Fakers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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

            var person = new PersonFaker().Generate(1).Single();

            //Console.WriteLine($"{config.GetSection("json").GetSection("SubSection")["SubSectionKey2"]} {person.LastName} {person.FirstName} {config.GetSection("json")["SectionKey1"]}!");
            Console.WriteLine($"{configApp.Json.SubSection.SubSectionKey2} {person.LastName} {person.FirstName} {configApp.Json.SectionKey1}!");
        }
    }
}
