using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FiggleConsoleService : IConsoleService
    {
        private ConsoleService _consoleService;
        
        public FiggleConsoleService(ConsoleService consoleService)
        {
            Console.WriteLine("FiggleConsoleService");
            _consoleService = consoleService;
        }

        public void WriteLine(string @string)
        {
            @string = Figgle.FiggleFonts.Standard.Render(@string);

            _consoleService.WriteLine(@string);
        }
    }
}
