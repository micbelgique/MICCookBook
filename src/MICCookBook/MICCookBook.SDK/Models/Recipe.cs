using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MICCookBook.SDK.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        [JsonIgnore]
        public string AbsolutePicture => "miccookbook.azurewebsites.net" + Picture;
    }
}
