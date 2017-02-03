namespace MICCookBook.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAndModifiedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluations", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Evaluations", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "ModifiedOn");
            DropColumn("dbo.Recipes", "CreatedOn");
            DropColumn("dbo.Evaluations", "ModifiedOn");
            DropColumn("dbo.Evaluations", "CreatedOn");
        }
    }
}
