using Day06.AdoDb;
using Day06.Entity;
using Day06.Repositories;
using Day06.Repository;
using Day06.Repository.Contract;
using Microsoft.Extensions.Configuration;
using System.Data;
using CustomerRepository = Day06.Repositories.CustomerRepository;

namespace Day06
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;

        private static async Task Main(string[] args)
        {
            BuildConfiguration();
            var adoDbContext = new AdoDbContext(Configuration.GetConnectionString("NorthWindDS"));

            //Employee
            IRepositoryBase<Employees> employeeRepository = new EmployeeRepository(adoDbContext);
            var employees = employeeRepository.FindAll();
            Console.WriteLine("\nFind All Employee ");
            Console.WriteLine("========================================\n");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee}");
            }

            var employeeByID = employeeRepository.FindByID(6);
            Console.WriteLine("\nFind By ID Employee");
            Console.WriteLine("========================================\n");

            Console.WriteLine(employeeByID);

            Console.WriteLine($"\nCreate Employee");
            Console.WriteLine("========================================\n");
            //5. createEmployee, EmployeeId ga diisi, otomatis dari sequence database
            /*Employees employee1 = new Employees(1, "123 Main St", "Anytown", "CA", "!234", "USA", 10, "John", "Doe", "Sales Manager", "Mr.", new DateTime(1980, 1, 1), new DateTime(2015, 3, 1), "555-1234", "1234", "Lorem Ipsum Dolor Sit Amet", 5, "john_doe.png");
            employeeRepository.Insert(employee1);
            Console.WriteLine(employee1.ToString());
*/
            //6. Update Employee
            /*          Console.WriteLine($"\nUpdate Employee");
                      Console.WriteLine("========================================\n");

                      var findUpdateEmps = new Employees(9, "Ardi", "Wanis");

                      employeeRepository.Edit(findUpdateEmps);
                      Console.WriteLine(findUpdateEmps.ToString());
                      var updateCustomerByID = employeeRepository.FindById(findUpdateEmps.EmployeeID);

                      Console.WriteLine("\nUpdated By ID Customer");
                      Console.WriteLine("========================================\n");
                      Console.WriteLine(updateCustomerByID);
          */
            //7. delete employee by id 10
            /* employeeRepository.Remove(54);*/

            /*IRepository<Employees> repositoryDBEmployee = new RepositoryEmployee(adoDbContext);*/
            /*var employeesTaskAync = await repositoryDBEmployee.FindAllTaskEnumerableAsync();
            Console.WriteLine("\n\nTask IEnumerable Async interface Employee");
            Console.WriteLine("========================================\n");
            foreach (var employee in employeesTaskAync)
            {
                Console.WriteLine($"{employee}");
            }*/

            /*var employeesAync = repositoryDBEmployee.FindAllEnumerableAsync<Employees>();
            Console.WriteLine("\n\nIEnumerable Async interface Employee");
            Console.WriteLine("========================================\n");
            await foreach (var employee in employeesAync)
            {
                Console.WriteLine($"{employee}");
            }*/

            //EmployeeReposiotry
            /*IRepositoryBase<Employees> employeeDBRepository = new EmployeeRepository(adoDbContext);
            var employees = employeeDBRepository.FindAll<Employees>();
            Console.WriteLine("\n\nIEnumerable interface IRepositoryBase");
            Console.WriteLine("========================================\n");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee}");
            }*/
            /* //Ienumerator interface
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
             var employeeByName = repositoryDBEmployee.FindByName("A%");
             Console.WriteLine("\n\nFind By Name Employee");
             Console.WriteLine("========================================\n");
             foreach (var employee in employeeByName)
             {
                 Console.WriteLine(employee.ToString());
             }

             Console.WriteLine(employeeByName);

             Console.WriteLine($"\nCreate Employee \n");
             //5. createEmployee, EmployeeId ga diisi, otomatis dari sequence database
             Employees employee1 = new Employees("John", "Doe", "Sales Manager", "Mr.", new DateTime(1980, 1, 1), new DateTime(2015, 3, 1), "123 Main St", "Anytown", "CA", "!234", "USA", "555-1234", "1234", "Lorem Ipsum Dolor Sit Amet", 5, "john_doe.png");

             employee1 = repositoryDBEmployee.Create(ref employee1);
             Console.WriteLine(employee1.ToString());

             //6. Update Employee

             Console.WriteLine($"\nUpdate Employee \n");
             var findUpdateEmps = new Employees(8, "Widi", "Wini");

             var updateEmp = repositoryDBEmployee.Update(findUpdateEmps);
             Console.WriteLine(updateEmp.ToString());

             //7. delete employee by id 10
             repositoryDBEmployee.Delete(42);

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

             // Customer findBy ID
             var customerByID = repositoryDBCustomer.FindByID("BONAP");
             Console.WriteLine("\n\nFind By ID Customer");
             Console.WriteLine("========================================\n");

             Console.WriteLine(customerByID);
             // Customer findBy Name
             var customerByName = repositoryDBCustomer.FindByName("A%");
             Console.WriteLine("\n\nFind By Name Customer");
             Console.WriteLine("========================================\n");
             foreach (var customer in customerByName)
             {
                 Console.WriteLine(customer.ToString());
             }

             Console.WriteLine(customerByName);

             //5. create customer
             var customer1 = new Customers("DANDA", "ABC Company", "John Doe", "CEO", "123 Main St", "Anytown", "East", "12345", "USA", "555-1234", "555-5678");
             *//*{
                 CustomerID = "DANDA",
                 CompanyName = "ABC Company",
                 ContactName = "John Doe",
                 ContactTitle = "CEO",
                 Address = "123 Main St",
                 City = "Anytown",
                 Region = "East",
                 PostalCode = "12345",
                 Country = "USA",
                 Phone = "555-1234",
                 Fax = "555-5678"
             };*//*

             customer1 = repositoryDBCustomer.Create(ref customer1);

             Console.WriteLine("\n\nCreate Customer");
             Console.WriteLine("========================================\n");
             Console.WriteLine(customer1.ToString());

             //6. Update Customer
             var findUpdateCust = new Customers
             {
                 CustomerID = "BONAP",
                 ContactName = "Widi",
             };

             var updateCust = repositoryDBCustomer.Update(findUpdateCust);
             var updatedCustomerByID = repositoryDBCustomer.FindByID(findUpdateCust.CustomerID);

             Console.WriteLine("\nUpdated By ID Customer");
             Console.WriteLine("========================================\n");
             Console.WriteLine(updatedCustomerByID);

             //7. delete employee by id 10
             repositoryDBCustomer.Delete("DINDA");

             //Supplier

             IRepository<Suppliers> repositoryDBSupplier = new RepositorySupplier(adoDbContext);
             //Ienumerator interface
             var suppliers = repositoryDBSupplier.FindAllEnumerator();
             Console.WriteLine("IEnumerator interface Supplier\n");
             Console.WriteLine("========================================\n");
             while (suppliers.MoveNext())
             {
                 var supplier = suppliers.Current;
                 Console.WriteLine(supplier.ToString());
             }

             //Ienumerator interface
             var suppliers1 = repositoryDBSupplier.FindAllEnumerable();
             Console.WriteLine("\n\nIEnumerable interface suppliers");
             Console.WriteLine("========================================\n");
             foreach (var supplier in suppliers1)
             {
                 Console.WriteLine(supplier);
             }

             // Supplier findBy ID
             var supplierByID = repositoryDBSupplier.FindByID(4);
             Console.WriteLine("\n\nFind By ID Supplier");
             Console.WriteLine("========================================\n");

             Console.WriteLine(supplierByID);
             // Supplier findBy Name
             var supplierByName = repositoryDBSupplier.FindByName("A%");
             Console.WriteLine("\n\nFind By Name Supplier");
             Console.WriteLine("========================================\n");
             foreach (var supplier in supplierByName)
             {
                 Console.WriteLine(supplier.ToString());
             }

             Console.WriteLine(supplierByName);

             //5. create supplier
             var supplier1 = new Suppliers("ABC Suppliers", "John Supplier", "Sales Manager", "456 Supplier St", "Supplier City", "Supplier Region", "78901", "Supplier Country", "987-654-3210", "987-654-3211", "http://www.abcsuppliers.com");

             supplier1 = repositoryDBSupplier.Create(ref supplier1);

             Console.WriteLine("\n\nCreate Supplier");
             Console.WriteLine("========================================\n");
             Console.WriteLine(supplier1.ToString());

             //6. Update Supplier
             var findUpdateSupp = new Suppliers
             {
                 SupplierID = 8,
                 ContactName = "Widi",
             };

             var updateSupp = repositoryDBSupplier.Update(findUpdateSupp);
             var updatedSupplierByID = repositoryDBSupplier.FindByID(findUpdateSupp.SupplierID);

             Console.WriteLine("\nUpdated By ID Supplier");
             Console.WriteLine("========================================\n");
             Console.WriteLine(updatedSupplierByID);

             //7. delete employee by id 10
             repositoryDBSupplier.Delete("DINDA");*/
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