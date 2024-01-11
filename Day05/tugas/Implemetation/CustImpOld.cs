using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    public class CustImpOld : IRepositoryMockup<CustomerOld>
    {
        public void FindAll(List<CustomerOld> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public CustomerOld FindByID(List<CustomerOld> entityList, CustomerOld ent)
        {
            // Get CustomerOlds list
            List<CustomerOld> customersOld = entityList;

            // Find employee by ID
            CustomerOld foundCust = customersOld.Find(e => e.CustomerID == ent.CustomerID);

            if (foundCust == null)
            {
                Console.WriteLine("CustomerOld not found");
            }

            return foundCust;
        }

        public List<CustomerOld> InitListData()
        {
            List<CustomerOld> CustomerOlds = new List<CustomerOld>();
            CustomerOld cust1 = new CustomerOld
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
            CustomerOld cust2 = new CustomerOld
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

            Save(CustomerOlds, cust1);
            Save(CustomerOlds, cust2);

            return CustomerOlds;
        }

        public void Remove(List<CustomerOld> entityList, CustomerOld ent)
        {
            entityList.Remove(ent);
        }

        public void Save(List<CustomerOld> entityList, CustomerOld ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<CustomerOld> entityList, CustomerOld ent)
        {
            CustomerOld CustomerOld = entityList.FirstOrDefault(c => c.CustomerID == ent.CustomerID);
            if (CustomerOld != null)
            {
                CustomerOld.ContactName = ent.ContactName;
                CustomerOld.Phone = ent.Phone;
                Console.WriteLine("CustomerOld updated successfully");

                // Display updated
                FindByID(entityList, CustomerOld);
            }
            else
            {
                Console.WriteLine("CustomerOld Not Found \n");
            }
        }
    }
}