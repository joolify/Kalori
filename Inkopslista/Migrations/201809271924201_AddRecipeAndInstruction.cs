namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeAndInstruction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CookingTimeH = c.Int(nullable: false),
                        CookingTimeM = c.Int(nullable: false),
                        Persons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            AddColumn("dbo.Products", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Products", "Recipe_Id");
            AddForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Instructions", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Instructions", new[] { "Recipe_Id" });
            DropIndex("dbo.Products", new[] { "Recipe_Id" });
            DropColumn("dbo.Products", "Recipe_Id");
            DropTable("dbo.Instructions");
            DropTable("dbo.Recipes");
        }
    }
}
