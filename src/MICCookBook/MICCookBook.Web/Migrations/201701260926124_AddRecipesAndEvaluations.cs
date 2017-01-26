namespace MICCookBook.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipesAndEvaluations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluations", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "AuthorId" });
            DropIndex("dbo.Evaluations", new[] { "RecipeId" });
            DropIndex("dbo.Evaluations", new[] { "AuthorId" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Evaluations");
        }
    }
}
