using BarramentoDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BarramentoRepository.Repositories.ApiDogsFacts
{
    public class ApiDogFactsRepository : IApiDogFactsRepository
    {
        public async Task<IList<Dogsfact>> GetFactsApi(string url, List<int> quantidades)
        {
            var listasfacts = new List<Dogsfact>();
            var client = new HttpClient();
            //client.BaseAddress = new Uri($"{url}");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var item in quantidades)
            {
                HttpResponseMessage response = await client.GetAsync(url + item);
                if (response.IsSuccessStatusCode)
                {
                    var fact = response.Content.ReadAsAsync<Dogsfact>().Result;
                    listasfacts.Add(fact);
                   
                }
            }            
            return listasfacts;
        }
    }
}
