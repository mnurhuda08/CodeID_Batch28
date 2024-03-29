﻿using Microsoft.Extensions.Configuration;
using WeeklyTestDapperDbContext.DapperDb;
using WeeklyTestDapperDbContext.Entity;
using WeeklyTestDapperDbContext.Repositories;
using WeeklyTestDapperDbContext.Repository.Contract;

namespace WeeklyTestDapperDbContext
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            BuildConfiguration();
            var dapperDbContext = new DapperDbContext(connection: Configuration.GetConnectionString("NorthwindDS"));

            //Supplier
            IRepositoryBase<Supplier> supplierRepository = new SupplierRepositories(dapperDbContext);
            Console.WriteLine("\nFind All Suppliers ");
            Console.WriteLine("========================================\n");
            var suppliers = supplierRepository.FindAll();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"{supplier}");
            }

            Console.WriteLine("\nFind By ID Supplier ");
            Console.WriteLine("========================================\n");
            var supplierByID = supplierRepository.FindByID(8);
            Console.WriteLine($"{supplierByID}");

            Console.WriteLine("\nCreate Supplier ");
            Console.WriteLine("========================================\n");
            var newSupplier = new Supplier()
            {
                CompanyName = "ABC Company",
                ContactName = "John Doe",
                ContactTitle = "COO",
                Phone = "555-1234"
            };
            newSupplier = supplierRepository.Create(ref newSupplier);
            Console.WriteLine($"{newSupplier}");

            Console.WriteLine("\nUpdate Supplier ");
            Console.WriteLine("========================================\n");
            var updateSupplierData = new Supplier()
            {
                SupplierID = 8,
                ContactName = "Peter Tugi"
            };
            var updateSupp = supplierRepository.Update(updateSupplierData);
            var updatedSuppData = supplierRepository.FindByID(updateSupp.SupplierID);
            Console.WriteLine($"{updatedSuppData}");

            Console.WriteLine("\nDelete Supplier ");
            Console.WriteLine("========================================\n");
            supplierRepository.Delete(32);
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            Console.WriteLine("Connected To Database using DapperDB...\n");
        }
    }
}