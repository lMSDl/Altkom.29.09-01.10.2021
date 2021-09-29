using System;
using System.Linq;
using System.Threading;
using Models;
using Services.Bogus.Fakers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonFaker().Generate(1).Single();

            Console.WriteLine($"Hello {person.LastName} {person.FirstName}!");
        }
    }
}
