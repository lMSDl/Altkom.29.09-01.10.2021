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
    public class AddressesController : BaseCrudController<Address>
    {
        private IService<Person> _peopleService;
        public AddressesController(IService<Address> service, IService<Person> peopleService) : base(service)
        {
            _peopleService = peopleService;
        }

        [HttpGet("{id}/people")]
        public IActionResult GetPeople(int id)
        {
            return Ok(_peopleService.Read().Where(x => x.AddressId == id));
        }
    }
}
