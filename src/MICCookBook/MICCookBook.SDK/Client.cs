using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MICCookBook.SDK.Model;
using Newtonsoft.Json;

namespace MICCookBook.SDK
{
    /// <summary>
    /// TODO : keep one instance of HttpClient accross multiple calls
    /// </summary>
    public class Client
    {
        public HttpClient HttpClient { get; set; }

        public Client()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:2011/api");
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            var content = await HttpClient.GetStringAsync("recipes");
            var recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);
            return recipes;

        }
    }
}
