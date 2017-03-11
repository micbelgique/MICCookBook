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
using System.Configuration;
using System.Threading;

namespace MICCookBook.Bot.Dialogs
{
    [Serializable]
    public class MainDialog : LuisDialog<object>
    {
        [NonSerialized]
        private Activity _activity;
        [NonSerialized]
        private IMessageActivity _message;


        public MainDialog(params ILuisService[] services): base(services)
        {

        }

        [LuisIntent(Intents.None)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.Forward(new CommonDialog(new LuisService(new LuisModelAttribute(
                            ConfigurationManager.AppSettings["CommonLuisModelId"],
                            ConfigurationManager.AppSettings["CommonLuisSubscriptionKey"]))),
                    BasicCallback, context.Activity as Activity, CancellationToken.None);
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
            await context.PostAsync($"{DialogCommon.Greet.Spintax()} !");
            context.Wait(MessageReceived);
        }

        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            _activity = (Activity)await item;
            await base.MessageReceived(context, item);
        }

        private async Task BasicCallback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}