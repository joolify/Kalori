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
            /*
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "LivsmedelsDB_20180923_new.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.MissingFieldFound = null;
                    while (csvReader.Read())
                    {
                        var product = csvReader.GetRecord<Product>();
                        var foodID = csvReader.GetField<int>("FoodId");
                        product.FoodId = context.Food.Local.Single(c => c.Id == foodID);
                        context.Product.AddOrUpdate(p => p.Price, product);
                    }
                }
            }
            */
        }
       
    }
}
