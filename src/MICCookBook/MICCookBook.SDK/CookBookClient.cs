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
            HttpClient.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            // TODO : make this more generic
            try
            {
                var response = await HttpClient.GetAsync(new Uri("http://miccookbook.azurewebsites.net/api/recipes"));
                var content = await response.Content.ReadAsStringAsync();
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);
                return recipes;
            }
            catch (Exception e)
            {
                // TODO : Propagate exception to caller
                return new List<Recipe>();
            }
        }

        public async Task<Recipe> GetRecipeDetails(string id)
        {
            // TODO : make this more generic
            try
            {
                var response = await HttpClient.GetAsync(new Uri($"http://miccookbook.azurewebsites.net/api/recipes/details/{id}"));
                var content = await response.Content.ReadAsStringAsync();
                var recipe = JsonConvert.DeserializeObject<Recipe>(content);
                return recipe;
            }
            catch (Exception e)
            {
                // TODO : Propagate exception to caller
                return new Recipe();
            }
        }
    }
}
