using EFCore_AdventureWorks2019Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_AdventureWorks2019App
{
    internal class Program
    {
        private static IConfigurationRoot _configuration;
        //instance to DB
        private static DbContextOptionsBuilder<AdventureWorks2019Context> _options;
        static void Main(string[] args)
        {
            BuildConfiguration();
            Console.WriteLine($"Connecting to : {_configuration.GetConnectionString("AdventureDS")}");
            BuildOption();

            GetAllPerson();
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        static  void BuildOption()
        {
            _options = new DbContextOptionsBuilder<AdventureWorks2019Context>();
            _options.UseSqlServer(_configuration.GetConnectionString("AdventureDS"));
        }

        static void GetAllPerson()
        {
            using (var db = new AdventureWorks2019Context(_options.Options))
            {
                var people = db.People.OrderByDescending(p=> p.FirstName).Take(25).ToList();

                foreach (var item in people)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }
            }
        }
    }
}
