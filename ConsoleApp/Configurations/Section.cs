using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Configurations
{
    public class Section
    {
        public string SectionKey1 { get; set; }
        public SubSection SubSection { get; set; }
        public int[] Values { get; set; }
    }
}
