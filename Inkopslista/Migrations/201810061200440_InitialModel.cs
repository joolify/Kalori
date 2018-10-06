namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Byte(nullable: false),
                        Name = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category1 = c.Int(),
                        Category2 = c.Int(),
                        Category3 = c.Int(),
                        Alkohol = c.Single(),
                        Arakidinsyra = c.Single(),
                        Arakidonsyra = c.Single(),
                        Aska = c.Single(),
                        Avfall = c.Single(),
                        DHA = c.Single(),
                        Disackarider = c.Single(),
                        DPA = c.Single(),
                        EnergiKJ = c.Single(),
                        EnergiKcal = c.Single(),
                        EPA = c.Single(),
                        Fett = c.Single(),
                        Fettsyra = c.Single(),
                        Fibrer = c.Single(),
                        Folat = c.Single(),
                        Fosfor = c.Single(),
                        FullkornTotalt = c.Single(),
                        Jod = c.Single(),
                        Jarn = c.Single(),
                        Kalcium = c.Single(),
                        Kalium = c.Single(),
                        Karoten = c.Single(),
                        Kolesterol = c.Single(),
                        Kolhydrater = c.Single(),
                        Koppar = c.Single(),
                        Laurinsyra = c.Single(),
                        Linolensyra = c.Single(),
                        Linolsyra = c.Single(),
                        Magnesium = c.Single(),
                        Monosackarider = c.Single(),
                        Myristinsyra = c.Single(),
                        Natrium = c.Single(),
                        Niacin = c.Single(),
                        Niacinekvivalenter = c.Single(),
                        Oljesyra = c.Single(),
                        Palmitinsyra = c.Single(),
                        Palmitoljesyra = c.Single(),
                        Protein = c.Single(),
                        Retinol = c.Single(),
                        Riboflavin = c.Single(),
                        Sackaros = c.Single(),
                        Salt = c.Single(),
                        Selen = c.Single(),
                        Sockerarter = c.Single(),
                        Stearinsyra = c.Single(),
                        Starkelse = c.Single(),
                        SummaEnkelOmattadeFettsyror = c.Single(),
                        SummaFleromattadeFettsyror = c.Single(),
                        SummaMattadeFettsyror = c.Single(),
                        Tiamin = c.Single(),
                        Vatten = c.Single(),
                        VitaminA = c.Single(),
                        VitaminB6 = c.Single(),
                        VitaminB12 = c.Single(),
                        VitaminC = c.Single(),
                        VitaminD = c.Single(),
                        VitaminE = c.Single(),
                        VitaminK = c.Single(),
                        Zink = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignupFee = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceTotal = c.Single(),
                        PricePerKg = c.Single(),
                        FoodId = c.Int(),
                        CategoryTypeId = c.Int(nullable: false),
                        FoodName = c.String(),
                        Mass = c.Single(),
                        ShoppinglistId = c.Int(),
                        RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId)
                .ForeignKey("dbo.Shoppinglists", t => t.ShoppinglistId)
                .Index(t => t.FoodId)
                .Index(t => t.CategoryTypeId)
                .Index(t => t.ShoppinglistId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CookingTimeH = c.Int(nullable: false),
                        CookingTimeM = c.Int(nullable: false),
                        Portions = c.Int(nullable: false),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Shoppinglists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ShoppinglistId", "dbo.Shoppinglists");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Instructions", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.Products", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Products", "CategoryTypeId", "dbo.CategoryTypes");
            DropForeignKey("dbo.Members", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Recipes", new[] { "Image_Id" });
            DropIndex("dbo.Products", new[] { "RecipeId" });
            DropIndex("dbo.Products", new[] { "ShoppinglistId" });
            DropIndex("dbo.Products", new[] { "CategoryTypeId" });
            DropIndex("dbo.Products", new[] { "FoodId" });
            DropIndex("dbo.Members", new[] { "MembershipTypeId" });
            DropIndex("dbo.Instructions", new[] { "RecipeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Shoppinglists");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Images");
            DropTable("dbo.Recipes");
            DropTable("dbo.Products");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Members");
            DropTable("dbo.Instructions");
            DropTable("dbo.Foods");
            DropTable("dbo.CategoryTypes");
        }
    }
}
