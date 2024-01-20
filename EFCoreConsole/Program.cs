using EFCoreLibrary;
using EFCoreLibrary.AdventureContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace EFCoreConsole
{
    internal class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<AdventureWorks2019Context> _optionBuilder;

        private static void Main(string[] args)
        {
            BuildConfiguration();
            BuildOptions();
            ListPersons();
            InsertPerson();
            GetPersonByFirstName();
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();

            Console.WriteLine("Connected To Database...\n");
            Console.WriteLine(_configuration.GetConnectionString("AdventureDS"));
        }

        private static void BuildOptions()
        {
            _optionBuilder = new DbContextOptionsBuilder<AdventureWorks2019Context>();
            _optionBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureDS"));
        }

        private static void ListPersons()
        {
            using (var db = new AdventureWorks2019Context(_optionBuilder.Options))
            {
                var persons = db.People.OrderBy(p => p.FirstName).Take(25).ToList();
                foreach (var person in persons)
                {
                    Console.WriteLine($"Person Name : {person.FirstName} {person.LastName}");
                }
            }
        }

        private static void GetPersonByFirstName()
        {
            using (var db = new AdventureWorks2019Context(_optionBuilder.Options))
            {
                var person = db.People.FirstOrDefault(p => p.FirstName == "Echo");
                if (person != null)
                {
                    Console.WriteLine("Single Person:");
                    Console.WriteLine($"Full Name: {person.FirstName} {person.MiddleName} {person.LastName}");
                }
                else
                {
                    Console.WriteLine("Person with FirstName 'Ken' not found.");
                }
            }
        }

        private static void InsertPerson()
        {
            using (var db = new AdventureWorks2019Context(_optionBuilder.Options))
            {
                BusinessEntity busineesEntity = new BusinessEntity();
                db.Add(busineesEntity);
                db.SaveChanges();
                Console.WriteLine($"Businees Entity = {busineesEntity.BusinessEntityId}");

                var person = new Person
                {
                    BusinessEntityId = busineesEntity.BusinessEntityId,
                    PersonType = "EM",
                    NameStyle = false,
                    Title = null,
                    FirstName = "Echo",
                    MiddleName = "Slam",
                    LastName = "Jamalama",
                    Suffix = null,
                    EmailPromotion = 0,
                    AdditionalContactInfo = null,
                    Demographics = null,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                db.SaveChanges();

                Console.WriteLine($"Bussenis Entity ID: {person.BusinessEntityId}");
                Console.WriteLine($"Full Name: {person.FirstName} {person.MiddleName} {person.LastName}");

                //find person
                var foundPerson = db.People.Find(busineesEntity.BusinessEntityId);
                Console.WriteLine($"Find Person");
                Console.WriteLine($"{foundPerson.BusinessEntity} - {foundPerson.FirstName} {foundPerson.MiddleName} {foundPerson.LastName}");

                //update Person
                person.FirstName = "Alberdo";
                person.LastName = "Huwahaha";
                db.Update(person);
                db.SaveChanges();
                Console.WriteLine($"Update Person");
                Console.WriteLine($"Bussenis Entity ID: {foundPerson.BusinessEntityId}");
                Console.WriteLine($"Full Name: {foundPerson.FirstName} {foundPerson.MiddleName} {foundPerson.LastName}");

                //delete Person
                Console.WriteLine($"Delete Person");
                db.People.Remove(foundPerson);
                db.SaveChanges();
            }
        }
    }
}