using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace MICCookBook.Bot.Luis
{
    /// <summary>
    ///     Base class used to handle the Common Luis model's intents.
    /// </summary>
    [Serializable]
    public abstract class CommonLuisDialog : LuisDialog<object>
    {
        protected CommonLuisDialog(params ILuisService[] services)
            : base(services)
        {
        }

        [LuisIntent(CommonIntents.None)]
        public virtual async Task None(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Greetings)]
        public virtual async Task Greetings(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Feelings)]
        public virtual async Task Feelings(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Compliment)]
        public virtual async Task Compliment(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Insult)]
        public virtual async Task Insult(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Name)]
        public virtual async Task Name(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Age)]
        public virtual async Task Age(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Home)]
        public virtual async Task Home(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Reality)]
        public virtual async Task Reality(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.InfoRequest)]
        public virtual async Task Infos(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Help)]
        public virtual async Task Help(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Thanks)]
        public virtual async Task Thanks(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.JokeRequest)]
        public virtual async Task Joke(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        [LuisIntent(CommonIntents.Time)]
        public virtual async Task Time(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }
    }
}