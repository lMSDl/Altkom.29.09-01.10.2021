using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bogus.Fakers
{
    public class AddressFaker : EntityFaker<Address>
    {
        public AddressFaker()
        {
            RuleFor(x => x.City, x => x.Address.City());
            RuleFor(x => x.Street, x => x.Address.StreetName());
        }
    }
}
