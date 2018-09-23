namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        Alkohol = c.Single(nullable: false),
                        ArakidinsyraC20 = c.Single(nullable: false),
                        ArakidonsyraC20 = c.Single(nullable: false),
                        Aska = c.Single(nullable: false),
                        Avfall = c.Single(nullable: false),
                        DHA = c.Single(nullable: false),
                        Disackarider = c.Single(nullable: false),
                        DPA = c.Single(nullable: false),
                        EnergiKJ = c.Single(nullable: false),
                        EnergiKcal = c.Single(nullable: false),
                        EPA = c.Single(nullable: false),
                        Fett = c.Single(nullable: false),
                        Fettsyra4_10 = c.Single(nullable: false),
                        Fibrer = c.Single(nullable: false),
                        Folat = c.Single(nullable: false),
                        Fosfor = c.Single(nullable: false),
                        FullkornTotalt = c.Single(nullable: false),
                        Jod = c.Single(nullable: false),
                        Jarn = c.Single(nullable: false),
                        Kalcium = c.Single(nullable: false),
                        Kalium = c.Single(nullable: false),
                        Karoten = c.Single(nullable: false),
                        Kolesterol = c.Single(nullable: false),
                        Kolhydrater = c.Single(nullable: false),
                        Koppar = c.Single(nullable: false),
                        LaurinsyraC12 = c.Single(nullable: false),
                        LinolensyraC18 = c.Single(nullable: false),
                        LinolsyraC18 = c.Single(nullable: false),
                        Magnesium = c.Single(nullable: false),
                        Monosackarider = c.Single(nullable: false),
                        Myristinsyra = c.Single(nullable: false),
                        Natrium = c.Single(nullable: false),
                        Niacin = c.Single(nullable: false),
                        Niacinekvivalenter = c.Single(nullable: false),
                        OljesyraC18 = c.Single(nullable: false),
                        PalmitinsyraC16 = c.Single(nullable: false),
                        Palmitoljesyra_C16 = c.Single(nullable: false),
                        Protein = c.Single(nullable: false),
                        Retinol = c.Single(nullable: false),
                        Riboflavin = c.Single(nullable: false),
                        Sackaros = c.Single(nullable: false),
                        Salt = c.Single(nullable: false),
                        Selen = c.Single(nullable: false),
                        Sockerarter = c.Single(nullable: false),
                        StearinsyraC18 = c.Single(nullable: false),
                        Starkelse = c.Single(nullable: false),
                        SummaEnkelOmattadeFettsyror = c.Single(nullable: false),
                        SummaFleromattadeFettsyror = c.Single(nullable: false),
                        SummaMattadeFettsyror = c.Single(nullable: false),
                        Tiamin = c.Single(nullable: false),
                        Vatten = c.Single(nullable: false),
                        VitaminA = c.Single(nullable: false),
                        VitaminB6 = c.Single(nullable: false),
                        VitaminB12 = c.Single(nullable: false),
                        VitaminC = c.Single(nullable: false),
                        VitaminD = c.Single(nullable: false),
                        VitaminE = c.Single(nullable: false),
                        VitaminK = c.Single(nullable: false),
                        Zink = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .Index(t => t.Food_Id);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "Food_Id", "dbo.Foods");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "Food_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Movies");
            DropTable("dbo.Foods");
            DropTable("dbo.Customers");
        }
    }
}
