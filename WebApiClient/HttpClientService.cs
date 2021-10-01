using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class HttpClientService
    {
        //package Microsoft.AspNet.WebApi.Client
        public HttpClient Client { get; }

        public HttpClientService(string baseAddress) : this(new HttpClient { BaseAddress = new Uri(baseAddress) })
        {
        }

        public HttpClientService(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string resource)
        {
            var response = await Client.GetAsync(resource);

            response.EnsureSuccessStatusCode();
            /*if(response.IsSuccessStatusCode)
            {
            }
            else
            {
            }*/

            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> GetAsync<T, Tid>(string resource, Tid id)
        {
            var response = await Client.GetAsync($"{resource}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }


        public async Task<Tresult> PostAsync<T, Tresult>(string resource, T entity)
        {
            var response = await Client.PostAsJsonAsync(resource, entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Tresult>();
        }
        public async Task<string> PostAsync<T>(string resource, T entity)
        {
            var response = await Client.PostAsJsonAsync(resource, entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task PutAsync<T, TId>(string resource, TId id, T entity)
        {
            var response = await Client.PutAsJsonAsync($"{resource}/{id}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync<Tid>(string resource, Tid id)
        {
            var response = await Client.DeleteAsync($"{resource}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
