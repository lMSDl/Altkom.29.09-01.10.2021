using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ConsoleService : IConsoleService
    {
        public ConsoleService()
        {
            Console.WriteLine("ConsoleService");
        }

        public void WriteLine(string @string)
        {
            Console.WriteLine(@string);
        }
    }
}
