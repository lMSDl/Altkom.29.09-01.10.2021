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
    public abstract class BaseCrudController<T> : BaseController where T : Entity
    {
        private IService<T> _service;

        public BaseCrudController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Read());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var person = _service.Read(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post(T person)
        {
            var personId = _service.Create(person);
            person = _service.Read(personId);

            return CreatedAtAction(nameof(Get), new { id = personId }, person);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, T person)
        {
            if (_service.Read(id) == null)
                return NotFound();

            _service.Update(id, person);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_service.Read(id) == null)
                return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}
