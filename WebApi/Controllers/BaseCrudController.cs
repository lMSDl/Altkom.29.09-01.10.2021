using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public abstract class BaseCrudController<T> : BaseController where T : Entity
    {
        private IService<T> _service;

        public BaseCrudController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ServiceFilter(typeof(SampleAsyncActionFilter))]
        [Authorize(Roles = "Read")]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3000);

            return Ok(_service.Read());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Read")]
        public virtual IActionResult Get(int id)
        {
            var person = _service.Read(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Write")]
        public IActionResult Post(T entity)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityId = _service.Create(entity);
            entity = _service.Read(entityId);

            return CreatedAtAction(nameof(Get), new { id = entityId }, entity);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Write")]
        public IActionResult Put(int id, T person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_service.Read(id) == null)
                return NotFound();

            _service.Update(id, person);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Delete")]
        public IActionResult Delete(int id)
        {
            if (_service.Read(id) == null)
                return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}
