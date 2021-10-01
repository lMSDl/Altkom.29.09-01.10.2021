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
        private HttpClient _client;

        public HttpClientService(string baseAddress) : this(new HttpClient { BaseAddress = new Uri(baseAddress) })
        {
        }

        public HttpClientService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string resource)
        {
            var response = await _client.GetAsync(resource);

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
            var response = await _client.GetAsync($"{resource}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }


        public async Task<Tresult> PostAsync<T, Tresult>(string resource, T entity)
        {
            var response = await _client.PostAsJsonAsync(resource, entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Tresult>();
        }

        public async Task PutAsync<T, TId>(string resource, TId id, T entity)
        {
            var response = await _client.PutAsJsonAsync($"{resource}/{id}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync<Tid>(string resource, Tid id)
        {
            var response = await _client.DeleteAsync($"{resource}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
