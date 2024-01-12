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

            //Employee
            IRepositoryEmployee repositoryDBEmployee = new RepositoryEmployee(adoDbContext);

            //Ienumerator interface
            var employees = repositoryDBEmployee.FindAllEnumerator();
            Console.WriteLine("IEnumerator interface Employee\n");
            Console.WriteLine("========================================\n");
            while (employees.MoveNext())
            {
                var employee = employees.Current;
                Console.WriteLine(employee.ToString());
            }

            //Ienumerator interface
            var employees1 = repositoryDBEmployee.FindAllEnumerable();
            Console.WriteLine("\n\nIEnumerable interface Employee");
            Console.WriteLine("========================================\n");
            foreach (var employee in employees1)
            {
                Console.WriteLine(employee);
            }

            // Employee findBy ID
            var employeeByID = repositoryDBEmployee.FindByID(2);
            Console.WriteLine("\n\nFind By ID Employee");
            Console.WriteLine("========================================\n");

            Console.WriteLine(employeeByID);
            // Employee findBy Name
            var employeeByName = repositoryDBEmployee.FindEmployeeByFirstName("A%");
            Console.WriteLine("\n\nFind By Name Employee");
            Console.WriteLine("========================================\n");
            foreach (var employee in employeeByName)
            {
                Console.WriteLine(employee.ToString());
            }

            Console.WriteLine(employeeByName);
            //5. createEmployee, EmployeeId ga diisi, otomatis dari sequence database
            var employee1 = new Employees
            {
                EmployeeID = 10,
                FirstName = "John",
                LastName = "Doe",
                Title = "Sales Manager",
                TitleOfCourtesy = "Mr.",
                BirthDate = new DateTime(1980, 1, 1),
                HireDate = new DateTime(2015, 3, 1),
                Address = "123 Main St",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                HomePhone = "555-1234",
                Extension = "1234",
                Notes = "Lorem Ipsum Dolor Sit Amet",
                ReportsTo = 5,
                PhotoPath = "john_doe.png",
            };

            employee1 = repositoryDBEmployee.Create(ref employee1);
            Console.WriteLine(employee1.ToString());

            //6. Update Employee
            var findUpdateEmps = new Employees
            {
                EmployeeID = 8,
                FirstName = "Widi",
                LastName = "Wini",
                BirthDate = DateTime.Now
            };

            var updateEmp = repositoryDBEmployee.Update(findUpdateEmps);
            Console.WriteLine(updateEmp.ToString());

            //7. delete employee by id 10
            repositoryDBEmployee.Delete(10);

            //Suppliers

            IRepository<Suppliers> repositoryDBSupplier = new RepositorySupplier(adoDbContext);
            //Ienumerator interface
            var suppliers = repositoryDBSupplier.FindAllEnumerator();
            Console.WriteLine("IEnumerator interface Suppliers\n");
            Console.WriteLine("========================================\n");
            while (suppliers.MoveNext())
            {
                var supplier = suppliers.Current;
                Console.WriteLine(supplier.ToString());
            }

            //Ienumerator interface
            var suppliers1 = repositoryDBSupplier.FindAllEnumerable();
            Console.WriteLine("\n\nIEnumerable interface Suppliers");
            Console.WriteLine("========================================\n");
            foreach (var supplier in suppliers1)
            {
                Console.WriteLine(supplier);
            }

            //CUSTOMER

            IRepository<Customers> repositoryDBCustomer = new RepositoryCustomer(adoDbContext);
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
            Console.WriteLine("\n\nIEnumerable interface customers");
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