namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToRecipe : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Recipe_Id", newName: "RecipeId");
            RenameIndex(table: "dbo.Products", name: "IX_Recipe_Id", newName: "IX_RecipeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_RecipeId", newName: "IX_Recipe_Id");
            RenameColumn(table: "dbo.Products", name: "RecipeId", newName: "Recipe_Id");
        }
    }
}
