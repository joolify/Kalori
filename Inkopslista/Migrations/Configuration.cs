using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CsvHelper;
using CsvHelper.TypeConversion;
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
            string resourceName = "Inkopslista.SeedData.LivsmedelsDB_20180925.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    try
                    {
                        CsvReader csvReader = new CsvReader(reader);
                        csvReader.Configuration.Delimiter = ";";
                        csvReader.Configuration.MissingFieldFound = null;
                        csvReader.Configuration.HasHeaderRecord = true;
                        csvReader.Configuration.PrepareHeaderForMatch = (header) => header.ToLower();

                        var floatOptions = new TypeConverterOptions
                        {
                            CultureInfo = new CultureInfo("sv-SE"),
                            NumberStyle = NumberStyles.Float
                        };
                        csvReader.Configuration.TypeConverterOptionsCache.AddOptions(typeof(float), floatOptions);

                        var foods = csvReader.GetRecords<Food>().ToArray();
                        context.Foods.AddOrUpdate(c => c.Name, foods);
                        context.SaveChanges();
                    }
                    catch (CsvHelperException e)
                    {
                        Console.WriteLine(e.Data.Values);
                        throw;
                    }

                }
            }

            resourceName = "Inkopslista.SeedData.Category.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    try
                    {
                        CsvReader csvReader = new CsvReader(reader);
                        csvReader.Configuration.Delimiter = ";";
                        csvReader.Configuration.MissingFieldFound = null;
                        csvReader.Configuration.HasHeaderRecord = true;
                        csvReader.Configuration.PrepareHeaderForMatch = (header) => header.ToLower();

                        var categoryTypes = csvReader.GetRecords<CategoryType>().ToArray();
                        context.CategoryTypes.AddOrUpdate(c => c.Category, categoryTypes);
                        context.SaveChanges();
                    }
                    catch (CsvHelperException e)
                    {
                        Console.WriteLine(e.Data.Values);
                        throw;
                    }

                }
            }

            resourceName = "Inkopslista.SeedData.MembershipTypes.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    try
                    {
                        CsvReader csvReader = new CsvReader(reader);
                        csvReader.Configuration.Delimiter = ";";
                        csvReader.Configuration.MissingFieldFound = null;
                        csvReader.Configuration.HasHeaderRecord = true;
                        csvReader.Configuration.PrepareHeaderForMatch = (header) => header.ToLower();

                        var membershipTypes = csvReader.GetRecords<MembershipType>().ToArray();
                        context.MembershipTypes.AddOrUpdate(c => c.Name, membershipTypes);
                        context.SaveChanges();
                    }
                    catch (CsvHelperException e)
                    {
                        Console.WriteLine(e.Data.Values);
                        throw;
                    }

                }
            }
        }

    }
}