using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class PeopleService : IService<Person>
    {
        private HttpClientService _service;

        public PeopleService(HttpClientService service)
        {
            _service = service;
        }

        public int Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
