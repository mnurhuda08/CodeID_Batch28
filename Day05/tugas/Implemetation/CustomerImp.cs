using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    public class CustomerImp : IRepositoryMockup<Customer>
    {
        public void FindAll(List<Customer> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public Customer FindByID(List<Customer> entityList, Customer ent)
        {
            // Get customers list
            List<Customer> customers = entityList;

            // Find employee by ID
            Customer foundCust = customers.Find(e => e.CustomerID == ent.CustomerID);

            if (foundCust == null)
            {
                Console.WriteLine("Customer not found");
            }

            return foundCust;
        }

        public List<Customer> InitListData()
        {
            List<Customer> customers = new List<Customer>();
            Customer cust1 = new Customer
            {
                CustomerID = 1,
                CompanyName = "Acme Corp",
                ContactName = "John Doe",
                ContactTitle = "Sales Manager",
                Address = "123 Main St",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Phone = "(555) 123-4567",
                Fax = "(555) 123-4568"
            };
            Customer cust2 = new Customer
            {
                CustomerID = 2,
                CompanyName = "ABC Ltd",
                ContactName = "Jane Smith",
                ContactTitle = "Marketing Manager",
                Address = "456 Oak Rd",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Phone = "(555) 987-6543",
            };

            Save(customers, cust1);
            Save(customers, cust2);

            return customers;
        }

        public void Remove(List<Customer> entityList, Customer ent)
        {
            entityList.Remove(ent);
        }

        public void Save(List<Customer> entityList, Customer ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<Customer> entityList, Customer ent)
        {
            Customer customer = entityList.FirstOrDefault(c => c.CustomerID == ent.CustomerID);
            if (customer != null)
            {
                customer.ContactName = ent.ContactName;
                customer.Phone = ent.Phone;
                Console.WriteLine("Customer updated successfully");

                // Display updated
                FindAll(entityList);
            }
            else
            {
                Console.WriteLine("Customer Not Found \n");
            }
        }
    }
}