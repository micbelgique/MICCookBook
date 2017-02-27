using MICCookBook.Bot.Constant;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using MICCookBook.Bot.I18n;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MICCookBook.SDK.Model;
using MICCookBook.Bot.Utils;

namespace MICCookBook.Bot.Dialogs
{
    [Serializable]
    public class MainDialog : LuisDialog<object>
    {
        [NonSerialized]
        private Activity _activity;

        public MainDialog(params ILuisService[] services): base(services)
        {

        }

        [LuisIntent(Intents.None)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.UnknownIntent.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Recipes)]
        public async Task Recipes(IDialogContext context, LuisResult result)
        {
            context.Call(new RecipesDialog(result), RecipeCallback);
        }

        private async Task RecipeCallback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Greetings)]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{Dialog.Greetings.Spintax()} !");
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Home)]
        public async Task Home(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Home.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Age)]
        public async Task Age(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Age.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Name)]
        public async Task Name(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Name.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Joke)]
        public async Task Joke(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Joke.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Thanks)]
        public async Task Thanks(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Thanks.Spintax());
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Sexe)]
        public async Task Sexe(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Dialog.Sexe.Spintax());
            context.Wait(MessageReceived);
        }

        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            _activity = (Activity)await item;
            await base.MessageReceived(context, item);
        }
    }
}