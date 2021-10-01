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

            var user = await service.GetAsync<User, int>("Users", 1);
            var token = await service.PostAsync<User>("users/login", user);
            service.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            var resource = "people";

            var people = await service.GetAsync<Person>(resource);

            var person = await service.GetAsync<Person, int>(resource, 13);

            person = new Person() { FirstName = "Ewa", LastName = "Ewowska", AddressId = 2, PhoneNumber = "123-987-023" };

           person = await service.PostAsync<Person, Person>(resource, person);

            person.FirstName = "Monika";
            await service.PutAsync<Person, int>(resource, person.Id, person);

            person = await service.GetAsync<Person, int>(resource, person.Id);

            await service.DeleteAsync(resource, person.Id);

            person = await service.GetAsync<Person, int>(resource, person.Id);
        }
    }
}
