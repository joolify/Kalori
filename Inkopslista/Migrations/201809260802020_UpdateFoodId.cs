namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFoodId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FoodId", "dbo.Foods");
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Foods", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Foods", "Id");
            AddForeignKey("dbo.Products", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FoodId", "dbo.Foods");
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Foods", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Foods", "Id");
            AddForeignKey("dbo.Products", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
    }
}
