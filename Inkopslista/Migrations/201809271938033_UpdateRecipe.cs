namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Portions", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "Persons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Persons", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "Portions");
        }
    }
}
