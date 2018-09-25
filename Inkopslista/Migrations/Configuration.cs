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
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "LivsmedelsDB_20180925.csv"; 
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                Console.WriteLine(stream);
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.MissingFieldFound = null;
                    var foods = csvReader.GetRecords<Food>().ToArray();
                    context.Foods.AddOrUpdate(c => c.Id, foods);
                }
            }
        }
    }
}