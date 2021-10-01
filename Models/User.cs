using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
