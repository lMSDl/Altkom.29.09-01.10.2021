using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ServiceFilter(typeof(SampleActionFilter))]
    public class PeopleController : BaseCrudController<Person>
    {
        public PeopleController(IService<Person> service) : base(service)
        {
        }
    }
}
