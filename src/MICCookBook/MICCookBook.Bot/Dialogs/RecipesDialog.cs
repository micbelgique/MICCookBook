using MICCookBook.Bot.I18n;
using MICCookBook.SDK;
using MICCookBook.SDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MICCookBook.Bot.Dialogs
{
    [Serializable]
    public class RecipesDialog : IDialog<object>
    {
        [NonSerialized]
        private LuisResult _initIntent;

        public RecipesDialog(LuisResult result)
        {
            _initIntent = result;
        }

        public async Task StartAsync(IDialogContext context)
        {
            CookBookClient client = new CookBookClient();
            var recipes = await client.GetRecipes();
            await DisplayRecipes(context, recipes);
        }

        private async Task DisplayRecipes(IDialogContext context, IEnumerable<Recipe> recipes)
        {
            var msg = context.MakeMessage();
            msg.Text = "Voici quelques idées de recettes";
            msg.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            msg.Attachments = BuildRecipesCards(recipes).Select(x => x.ToAttachment()).ToList();
            await context.PostAsync(msg);
            context.Wait(RecipeCallback);
        }

        private async Task DisplayRecipeDetails(IDialogContext context, Recipe recipe)
        {
            var msg = context.MakeMessage();
            msg.Text = "Voici le détail de la recette";
            await context.PostAsync(msg);
        }

        #region CallBacks
        private async Task RecipeCallback(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            CookBookClient client = new CookBookClient();
            var activity = await result;
            try
            {
                var action = OrderButtonAction.FromJson(activity.Text);
                if (action.Type == 2)
                {
                    var recipe = await client.GetRecipeDetails(activity.Id);
                    await context.PostAsync($"{recipe.Description}");
                }
            }
            catch (Exception)
            {
                // todo: ewww
            }
            await context.PostAsync("Problème");
            // await DisplayItems(context); todo: display item list again?
        }

        #endregion

        #region Cards

        private List<HeroCard> BuildRecipesCards(IEnumerable<Recipe> recipes)
        {
            var cards = new List<HeroCard>();
            foreach (var recipe in recipes)
            {
                var image = new CardImage($"{ ConfigurationManager.AppSettings["WebAppUrl"] }{recipe.Picture}");
                var button = new CardAction
                {
                    Value = new OrderButtonAction { Type = 2, Value = recipe.Id }.ToJson(),
                    Title = "Commencer",
                    Type = ActionTypes.PostBack
                };
                cards.Add(new HeroCard
                {
                    Title = recipe.Title,
                    Buttons = new List<CardAction> { button },
                    Images = new List<CardImage> { image }
                });
            }

            return cards;
        }

        #endregion

    }

    internal class OrderButtonAction
    {
        public int Type { get; set; }
        public int Value { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static OrderButtonAction FromJson(string json)
        {
            return JsonConvert.DeserializeObject<OrderButtonAction>(json);
        }
    }
}