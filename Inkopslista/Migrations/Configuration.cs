using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using EntityFramework.Seeder;
using Inkopslista.Models;

namespace Inkopslista.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
     internal sealed class Configuration : DbMigrationsConfiguration<Inkopslista.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
         protected override void Seed(Inkopslista.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
             //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}