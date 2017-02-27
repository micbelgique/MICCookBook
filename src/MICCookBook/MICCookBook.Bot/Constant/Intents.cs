using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICCookBook.Bot.Constant
{
    public static class Intents
    {
        public const string None = "";
        public const string Recipes = "GetRecipes";
        public const string RecipesDetails = "GetRecipesDetails";

        // Base intents
        public const string Greetings = "Greetings";
        public const string Age = "Age";
        public const string Home = "Home";
        public const string Name = "Name";
        public const string Sexe = "Sexe";
        public const string Joke = "Joke";
        public const string Thanks = "Thanks";
    }
}