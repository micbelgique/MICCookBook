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
    public class CookBookClient
    {
        public HttpClient HttpClient { get; set; }

        public CookBookClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:2011/api");
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            // TODO : make this more generic
            try
            {
                var content = await HttpClient.GetStringAsync("recipes");
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);
                return recipes;
            }
            catch (Exception e)
            {
                // TODO : Propagate exception to caller
                return new List<Recipe>();
            }
        }
    }
}
