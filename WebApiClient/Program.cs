using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new HttpClientService("http://localhost:5000/api/");

            var resource = "people";

            var people = await service.GetAsync<Person>(resource);

            var person = await service.GetAsync<Person, int>(resource, 3);

            person = new Person() { FirstName = "Ewa", LastName = "Ewowska", AddressId = 2, PhoneNumber = "123-987-023" };

            int id = await service.PostAsync<Person, int>(resource, person);

            person.FirstName = "Monika";
            person.Id = 0;
            await service.PutAsync<Person, int>(resource, id, person);

            person = await service.GetAsync<Person, int>(resource, id);

            await service.DeleteAsync(resource, id);

            person = await service.GetAsync<Person, int>(resource, id);
        }
    }
}
