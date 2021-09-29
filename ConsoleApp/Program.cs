using System;
using System.Threading;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { FirstName = "Ewa", LastName = "Ewowska" };

            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Hello {person.LastName} {person.FirstName}!");
            }
        }
    }
}
