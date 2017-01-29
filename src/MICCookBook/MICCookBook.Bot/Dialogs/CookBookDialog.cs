using MICCookBook.SDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private Activity _message;
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

        [LuisIntent("GetRecipes")]
        public async Task GetRecipes(IDialogContext context, LuisResult result)
        {
            List<Recipe> recipes;

            using (var client = new HttpClient())
            {
                var url = $"{AppSrv}/api/Recipes";

                var httpResponse = await client.GetAsync(url);

                if (httpResponse.StatusCode == HttpStatusCode.OK)

                {
                    var x = await httpResponse.Content.ReadAsStringAsync();
                    recipes = JsonConvert.DeserializeObject<List<Recipe>>(x);

                    Activity replyToConversation = _message.CreateReply("Voici ce que je te propose");
                    replyToConversation.Recipient = _message.From;
                    replyToConversation.Type = "message";
                    replyToConversation.Attachments = new List<Attachment>();

                    List<CardAction> cardButtons = new List<CardAction>();

                    CardAction plButtonInfo = new CardAction()
                    {
                        Value = $"{AppSrv}",
                        Type = "openUrl",
                        Title = "Plus d'info"
                    };
                    cardButtons.Add(plButtonInfo);
                    CardAction plButtonOk = new CardAction()
                    {
                        Value = $"{AppSrv}",
                        Type = "openUrl",
                        Title = "Miam !"
                    };
                    cardButtons.Add(plButtonOk);

                    foreach (var recipe in recipes)
                    {
                        HeroCard plCard = new HeroCard()
                        {
                            Title = recipe.Title,
                            Text = recipe.Description,
                            Subtitle = "Pig Latin Wikipedia Page",
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
    }
}