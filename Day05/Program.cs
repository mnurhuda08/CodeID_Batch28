﻿using Day05.tugas.Entities;
using Day05.tugas.Implemetation;

namespace Day05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EmployeeSection();

            CustomerSection();

            SupplierSection();
        }

        private static void EmployeeSection()
        {
            Console.WriteLine("Employee");
            Console.WriteLine("=================================");
            var empInterface = new EmpImpOld();
            var listEmployee = empInterface.InitListData();

            empInterface.FindAll(listEmployee);

            EmployeeOld findEmpByID = new EmployeeOld
            {
                EmployeeID = 2
            };
            var findByID = empInterface.FindByID(listEmployee, findEmpByID);

            Console.WriteLine("Find By ID");
            Console.WriteLine("=================================");
            Console.WriteLine(findByID);

            // Create updated employee
            EmployeeOld updatedEmp = new EmployeeOld
            {
                EmployeeID = 1,
                FirstName = "Bob" // updated first name
            };
            // Call update
            Console.WriteLine("Update");
            Console.WriteLine("=================================");
            empInterface.Update(listEmployee, updatedEmp);
        }

        private static void CustomerSection()
        {
            Console.WriteLine("\nCustomer");
            Console.WriteLine("=================================");
            var custInterface = new CustImpOld();
            var listCustomer = custInterface.InitListData();

            custInterface.FindAll(listCustomer);

            CustomerOld findCustByID = new CustomerOld
            {
                CustomerID = 2
            };

            var findByID = custInterface.FindByID(listCustomer, findCustByID);

            Console.WriteLine("Find By ID");
            Console.WriteLine("=================================");
            Console.WriteLine(findByID);

            // Create updated customer
            CustomerOld updatedCust = new CustomerOld
            {
                CustomerID = 11,
                ContactName = "Alvares",
                Phone = "+621231283128" // updated first name
            };
            // Call update
            Console.WriteLine("Update");
            Console.WriteLine("=================================");
            custInterface.Update(listCustomer, updatedCust);
        }

        private static void SupplierSection()
        {
            Console.WriteLine("Supplier");
            Console.WriteLine("=================================");
            var suppInterface = new SupplierImpOld();
            var listSupplier = suppInterface.InitListData();

            suppInterface.FindAll(listSupplier);

            SupplierOld findSupByID = new SupplierOld
            {
                SupplierID = 1
            };

            var findByID = suppInterface.FindByID(listSupplier, findSupByID);

            Console.WriteLine("Find By ID");
            Console.WriteLine("=================================");
            Console.WriteLine(findByID);

            // Create updated customer
            SupplierOld updatedSupp = new SupplierOld
            {
                SupplierID = 1,
                ContactName = "Alvares",
                Phone = "+621231283128" // updated first name
            };

            // Call update
            Console.WriteLine("Update");
            Console.WriteLine("=================================");
            suppInterface.Update(listSupplier, updatedSupp);
            /*  private static void EmployeeSection()
              {
                  Console.WriteLine("Employee");
                  Console.WriteLine("=================================");
                  var empInterface = new EmployeeImp();
                  var listEmployee = empInterface.InitListData();

                  empInterface.FindAll(listEmployee);

                  Employee findEmpByID = new Employee();
                  findEmpByID.EmployeeID = 1;

                  var findByID = empInterface.FindByID(listEmployee, findEmpByID);

                  Console.WriteLine("Find By ID");
                  Console.WriteLine("=================================");
                  Console.WriteLine(findByID);

                  // Create updated employee
                  *//*            Employee updatedEmp = new Employee
                              {
                                  EmployeeID = 11,
                                  FirstName = "Bob" // updated first name
                              };

                              // Call update
                              empInterface.Update(listEmployee, updatedEmp);*//*
              }*/

            /* private static void CustomerSection()
             {
                 Console.WriteLine("Customer");
                 Console.WriteLine("=================================");
                 var custInterface = new CustomerImp();
                 var listCustomer = custInterface.InitListData();

                 custInterface.FindAll(listCustomer);

                 // Create updated customer
                 Customer updatedCust = new Customer
                 {
                     CustomerID = 11,
                     ContactName = "Alvares",
                     Phone = "+621231283128" // updated first name
                 };

                 // Call update
                 custInterface.Update(listCustomer, updatedCust);

                 Customer findCustByID = new Customer
                 {
                     CustomerID = 2
                 };

                 var findByID = custInterface.FindByID(listCustomer, findCustByID);

                 Console.WriteLine("Find By ID");
                 Console.WriteLine("=================================");
                 Console.WriteLine(findByID);
             }

             private static void SupplierSection()
             {
                 Console.WriteLine("Supplier");
                 Console.WriteLine("=================================");
                 var suppInterface = new SupplierImp();
                 var listSupplier = suppInterface.InitListData();

                 suppInterface.FindAll(listSupplier);

                 // Create updated customer
                 Supplier updatedSupp = new Supplier
                 {
                     SupplierID = 1,
                     ContactName = "Alvares",
                     Phone = "+621231283128" // updated first name
                 };

                 // Call update
                 suppInterface.Update(listSupplier, updatedSupp);

                 Supplier findSupByID = new Supplier
                 {
                     SupplierID = 1
                 };

                 var findByID = suppInterface.FindByID(listSupplier, findSupByID);

                 Console.WriteLine("Find By ID");
                 Console.WriteLine("=================================");
                 Console.WriteLine(findByID);
             }*/
        }
    }
}