using Newtonsoft.Json;

namespace MICCookBook.SDK.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        [JsonIgnore]
        public string PictureUrl => "http://mic-cookbook.azurewebsites.net" + Picture;
    }
}
