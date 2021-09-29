using Bogus;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bogus.Fakers
{
    public class EntityFaker<T> : Faker<T> where T : Entity
    {
        public EntityFaker() : base("pl")
        {
            StrictMode(true);
            RuleFor(x => x.Id, x => x.UniqueIndex);
        }
    }
}
