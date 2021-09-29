using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Configurations
{
    public class ConfigApp
    {
        public Section Json { get; set; }
        public Section Ini { get; set; }
        public Section Yaml { get; set; }
        public Section Xml { get; set; }
    }
}
