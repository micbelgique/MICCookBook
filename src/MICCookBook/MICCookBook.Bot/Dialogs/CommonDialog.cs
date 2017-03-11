using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using MICCookBook.Bot.Luis;
using MICCookBook.Bot.I18n;
using MICCookBook.Bot.Utils;
using Microsoft.Bot.Builder.Luis;

namespace MICCookBook.Bot.Dialogs
{
    [Serializable]
    public class CommonDialog : CommonLuisDialog
    {
        public CommonDialog(params ILuisService[] services): base(services)
        {

        }

        public override async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.UnknownIntent.Spintax());
            context.Done<object>(null);
        }

        public override async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Greet.Spintax());
            context.Done<object>(null);
        }

        public override async Task Feelings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Feelings.Spintax());
            context.Done<object>(null);
        }

        public override async Task Compliment(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Compliment.Spintax());
            context.Done<object>(null);
        }

        public override async Task Insult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Insult.Spintax());
            context.Done<object>(null);
        }

        public override async Task Name(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Name.Spintax());
            context.Done<object>(null);
        }

        public override async Task Age(IDialogContext context, LuisResult result)
        {
            var answer = string.Format(DialogCommon.Age.Spintax(), GetAge());
            await context.PostAsync(answer);
            context.Done<object>(null);
        }

        public override async Task Home(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Home.Spintax());
            context.Done<object>(null);
        }

        public override async Task Reality(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Robot.Spintax());
            context.Done<object>(null);
        }

        public override async Task Infos(IDialogContext context, LuisResult result)
        {
            var answer = string.Format(DialogCommon.Info.Spintax(), GetAge());
            await context.PostAsync(answer);
            context.Done<object>(null);
        }

        public override async Task Help(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        public override async Task Thanks(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(DialogCommon.Thanks.Spintax());
            context.Done<object>(null);
        }

        public override async Task Joke(IDialogContext context, LuisResult result)
        {
            context.Done<object>(null);
        }

        public override async Task Time(IDialogContext context, LuisResult result)
        {
            var answer = string.Format(DialogCommon.Time.Spintax(), DateTime.Now);
            await context.PostAsync(answer);
            context.Done<object>(null);
        }

        private TimeSpan GetAge()
        {
            return DateTime.Now - new DateTime(2017, 2, 10);
        }
    }
}