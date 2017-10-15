using System;

namespace MICCookBook.Views
{

    public class MasterDetailPageMenuItem
    {
        public MasterDetailPageMenuItem()
        {
            TargetType = typeof(RecipesPage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}