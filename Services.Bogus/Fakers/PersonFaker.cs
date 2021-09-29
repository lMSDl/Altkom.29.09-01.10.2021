using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bogus.Fakers
{
    public class PersonFaker : EntityFaker<Models.Person>
    {
        public PersonFaker()
        {
            RuleFor(x => x.FirstName, x => x.Person.FirstName);
            RuleFor(x => x.LastName, x => x.Person.LastName);
            RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumber());
        }
    }
}
