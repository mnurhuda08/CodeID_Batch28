using Day06.AdoDb;
using Day06.Entity;
using Day06.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Day06
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            BuildConfiguration();
            var adoDbContext = new AdoDbContext(Configuration.GetConnectionString("NorthWindDS"));

            IRepository<Suppliers> repositoryDBSupplier = new RepositoryDB<Suppliers>(adoDbContext);

            //Ienumerator interface
            var suppliers = repositoryDBSupplier.FindAllEnumerator();
            Console.WriteLine("IEnumerator interface supplier\n");
            Console.WriteLine("========================================\n");
            while (suppliers.MoveNext())
            {
                var supplier = suppliers.Current;
                Console.WriteLine(supplier.ToString());
            }

            //Ienumerator interface
            var suppliers1 = repositoryDBSupplier.FindAllEnumerable();
            Console.WriteLine("\n\nIEnumerable interface supplier");
            Console.WriteLine("========================================\n");
            foreach (var supplier in suppliers1)
            {
                Console.WriteLine(supplier);
            }

            IRepository<Customers> repositoryDBCustomer = new RepositoryDB<Customers>(adoDbContext);

            //Ienumerator interface
            var customers = repositoryDBCustomer.FindAllEnumerator();
            Console.WriteLine("IEnumerator interface Customer\n");
            Console.WriteLine("========================================\n");
            while (customers.MoveNext())
            {
                var customer = customers.Current;
                Console.WriteLine(customer.ToString());
            }

            //Ienumerator interface
            var customers1 = repositoryDBCustomer.FindAllEnumerable();
            Console.WriteLine("\n\nIEnumerable interface customer");
            Console.WriteLine("========================================\n");
            foreach (var customer in customers1)
            {
                Console.WriteLine(customer);
            }
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            Console.WriteLine("Connected To Database...\n");
            /*Console.WriteLine(Configuration.GetConnectionString("NorthWindDS"));*/
        }
    }
}