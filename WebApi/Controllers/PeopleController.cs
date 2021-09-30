using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class PeopleController : BaseCrudController<Person>
    {
        public PeopleController(IService<Person> service) : base(service)
        {
        }
    }
}
