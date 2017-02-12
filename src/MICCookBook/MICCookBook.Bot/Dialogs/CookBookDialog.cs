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
    public class CookBookDialog : LuisDialog<object>
    {
        public const string Entity_location = "Location";
        private static Activity _message;
        private string AppSrv = "http://localhost:2011";

        public CookBookDialog(params ILuisService[] services): base(services)
        {
            
        }

        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            _message = (Activity)await item;
            await base.MessageReceived(context, item);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = "Désolé je n'ai pas compris :/";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = "Bonjour ! Une petite faim ?";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Identification")]
        public async Task Identification(IDialogContext context, LuisResult result)
        {
            Activity replyToConversation = _message.CreateReply();
            replyToConversation.Recipient = _message.From;
            replyToConversation.Type = "message";

            replyToConversation.Attachments = new List<Attachment>();
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = $"{System.Configuration.ConfigurationManager.AppSettings["AppWebSite"]}/Home/Login?userid={HttpUtility.UrlEncode(_message.From.Id)}",
                Type = "signin",
                Title = "Authentication Required"
            };
            cardButtons.Add(plButton);
            SigninCard plCard = new SigninCard("Merci de vous identifier dans le MicCookBook", new List<CardAction>() { plButton });
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);

            await context.PostAsync(replyToConversation);
            context.Wait(MessageReceived);
        }


        [LuisIntent("GetRecipes")]
        public async Task GetRecipes(IDialogContext context, LuisResult result)
        {
            List<Recipe> recipes;

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(ConfigurationManager.AppSettings["ApiUrlRecipes"]);

                if (httpResponse.StatusCode == HttpStatusCode.OK)

                {
                    var x = await httpResponse.Content.ReadAsStringAsync();
                    recipes = JsonConvert.DeserializeObject<List<Recipe>>(x);

                    Activity replyToConversation = _message.CreateReply("Voici ce que je te propose");
                    replyToConversation.Recipient = _message.From;
                    replyToConversation.Type = "message";
                    replyToConversation.Attachments = new List<Attachment>();

                    foreach (var recipe in recipes)
                    {
                        List<CardAction> cardButtons = new List<CardAction>();

                        CardAction plButtonInfo = new CardAction()
                        {
                            Value = $"{ConfigurationManager.AppSettings["WebAppUrl"]}",
                            Type = "openUrl",
                            Title = "Voir sur le site"
                        };
                        cardButtons.Add(plButtonInfo);
                        CardAction plButtonOk = new CardAction()
                        {
                            Value = "Donne moi des infos sur cette recette",
                            Type = "imBack",
                            Title = "Commencer !"
                        };
                        cardButtons.Add(plButtonOk);


                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: $"{ ConfigurationManager.AppSettings["WebAppUrl"] }{recipe.Picture}"));

                        HeroCard plCard = new HeroCard()
                        {
                            Title = recipe.Title,
                            Text = recipe.Description,
                            // Subtitle = recipe.,  ToDo: Ajouter l'auteur de la recette
                            Images = cardImages,
                            Buttons = cardButtons
                        };

                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                    }

                    await context.PostAsync(replyToConversation);
                    context.Wait(MessageReceived);
                }
            }
        }

        [LuisIntent("GetRecipeDetails")]
        public async Task GetRecipeDetails(IDialogContext context, LuisResult result)
        {
            string message = "Ok on va regarder à cette recette";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}