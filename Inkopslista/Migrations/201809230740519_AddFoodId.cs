namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Products", new[] { "Food_Id" });
            RenameColumn(table: "dbo.Products", name: "Food_Id", newName: "FoodId");
            AlterColumn("dbo.Foods", "Alkohol", c => c.Single());
            AlterColumn("dbo.Foods", "ArakidinsyraC20", c => c.Single());
            AlterColumn("dbo.Foods", "ArakidonsyraC20", c => c.Single());
            AlterColumn("dbo.Foods", "Aska", c => c.Single());
            AlterColumn("dbo.Foods", "Avfall", c => c.Single());
            AlterColumn("dbo.Foods", "DHA", c => c.Single());
            AlterColumn("dbo.Foods", "Disackarider", c => c.Single());
            AlterColumn("dbo.Foods", "DPA", c => c.Single());
            AlterColumn("dbo.Foods", "EnergiKJ", c => c.Single());
            AlterColumn("dbo.Foods", "EnergiKcal", c => c.Single());
            AlterColumn("dbo.Foods", "EPA", c => c.Single());
            AlterColumn("dbo.Foods", "Fett", c => c.Single());
            AlterColumn("dbo.Foods", "Fettsyra4_10", c => c.Single());
            AlterColumn("dbo.Foods", "Fibrer", c => c.Single());
            AlterColumn("dbo.Foods", "Folat", c => c.Single());
            AlterColumn("dbo.Foods", "Fosfor", c => c.Single());
            AlterColumn("dbo.Foods", "FullkornTotalt", c => c.Single());
            AlterColumn("dbo.Foods", "Jod", c => c.Single());
            AlterColumn("dbo.Foods", "Jarn", c => c.Single());
            AlterColumn("dbo.Foods", "Kalcium", c => c.Single());
            AlterColumn("dbo.Foods", "Kalium", c => c.Single());
            AlterColumn("dbo.Foods", "Karoten", c => c.Single());
            AlterColumn("dbo.Foods", "Kolesterol", c => c.Single());
            AlterColumn("dbo.Foods", "Kolhydrater", c => c.Single());
            AlterColumn("dbo.Foods", "Koppar", c => c.Single());
            AlterColumn("dbo.Foods", "LaurinsyraC12", c => c.Single());
            AlterColumn("dbo.Foods", "LinolensyraC18", c => c.Single());
            AlterColumn("dbo.Foods", "LinolsyraC18", c => c.Single());
            AlterColumn("dbo.Foods", "Magnesium", c => c.Single());
            AlterColumn("dbo.Foods", "Monosackarider", c => c.Single());
            AlterColumn("dbo.Foods", "Myristinsyra", c => c.Single());
            AlterColumn("dbo.Foods", "Natrium", c => c.Single());
            AlterColumn("dbo.Foods", "Niacin", c => c.Single());
            AlterColumn("dbo.Foods", "Niacinekvivalenter", c => c.Single());
            AlterColumn("dbo.Foods", "OljesyraC18", c => c.Single());
            AlterColumn("dbo.Foods", "PalmitinsyraC16", c => c.Single());
            AlterColumn("dbo.Foods", "Palmitoljesyra_C16", c => c.Single());
            AlterColumn("dbo.Foods", "Protein", c => c.Single());
            AlterColumn("dbo.Foods", "Retinol", c => c.Single());
            AlterColumn("dbo.Foods", "Riboflavin", c => c.Single());
            AlterColumn("dbo.Foods", "Sackaros", c => c.Single());
            AlterColumn("dbo.Foods", "Salt", c => c.Single());
            AlterColumn("dbo.Foods", "Selen", c => c.Single());
            AlterColumn("dbo.Foods", "Sockerarter", c => c.Single());
            AlterColumn("dbo.Foods", "StearinsyraC18", c => c.Single());
            AlterColumn("dbo.Foods", "Starkelse", c => c.Single());
            AlterColumn("dbo.Foods", "SummaEnkelOmattadeFettsyror", c => c.Single());
            AlterColumn("dbo.Foods", "SummaFleromattadeFettsyror", c => c.Single());
            AlterColumn("dbo.Foods", "SummaMattadeFettsyror", c => c.Single());
            AlterColumn("dbo.Foods", "Tiamin", c => c.Single());
            AlterColumn("dbo.Foods", "Vatten", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminA", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminB6", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminB12", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminC", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminD", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminE", c => c.Single());
            AlterColumn("dbo.Foods", "VitaminK", c => c.Single());
            AlterColumn("dbo.Foods", "Zink", c => c.Single());
            AlterColumn("dbo.Products", "FoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "FoodId");
            AddForeignKey("dbo.Products", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FoodId", "dbo.Foods");
            DropIndex("dbo.Products", new[] { "FoodId" });
            AlterColumn("dbo.Products", "FoodId", c => c.Int());
            AlterColumn("dbo.Foods", "Zink", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminK", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminE", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminD", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminC", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminB12", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminB6", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "VitaminA", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Vatten", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Tiamin", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "SummaMattadeFettsyror", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "SummaFleromattadeFettsyror", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "SummaEnkelOmattadeFettsyror", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Starkelse", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "StearinsyraC18", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Sockerarter", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Selen", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Salt", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Sackaros", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Riboflavin", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Retinol", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Protein", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Palmitoljesyra_C16", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "PalmitinsyraC16", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "OljesyraC18", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Niacinekvivalenter", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Niacin", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Natrium", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Myristinsyra", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Monosackarider", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Magnesium", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "LinolsyraC18", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "LinolensyraC18", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "LaurinsyraC12", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Koppar", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Kolhydrater", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Kolesterol", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Karoten", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Kalium", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Kalcium", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Jarn", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Jod", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "FullkornTotalt", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Fosfor", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Folat", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Fibrer", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Fettsyra4_10", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Fett", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "EPA", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "EnergiKcal", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "EnergiKJ", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "DPA", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Disackarider", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "DHA", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Avfall", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Aska", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "ArakidonsyraC20", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "ArakidinsyraC20", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "Alkohol", c => c.Single(nullable: false));
            RenameColumn(table: "dbo.Products", name: "FoodId", newName: "Food_Id");
            CreateIndex("dbo.Products", "Food_Id");
            AddForeignKey("dbo.Products", "Food_Id", "dbo.Foods", "Id");
        }
    }
}
