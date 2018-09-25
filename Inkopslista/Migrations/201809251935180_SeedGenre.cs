namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Action')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Thriller')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Family')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Romance')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
