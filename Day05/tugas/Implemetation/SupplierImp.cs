using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    public class SupplierImp : IRepositoryMockup<Supplier>
    {
        public void FindAll(List<Supplier> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public Supplier FindByID(List<Supplier> entityList, Supplier ent)
        {
            // Get Supplier list
            List<Supplier> suppliers = entityList;

            // Find supplier by ID
            Supplier foundSupp = suppliers.Find(s => s.SupplierID == ent.SupplierID);

            if (foundSupp == null)
            {
                Console.WriteLine("Supplier not found");
            }

            return foundSupp;
        }

        public List<Supplier> InitListData()
        {
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supp1 = new Supplier
            {
                SupplierID = 1,
                CompanyName = "ABC Corp",
                ContactName = "Jane Doe",
                ContactTitle = "Purchasing Manager",
                Address = "123 Maple St",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Phone = "(555) 123-4567",
                Fax = "(555) 123-4568",
                Homepage = "www.abc-corp.com"
            };
            Supplier supp2 = new Supplier
            {
                SupplierID = 2,
                CompanyName = "Acme Ltd",
                ContactName = "John Smith",
                ContactTitle = "Sales Agent",
                Address = "456 Elm Rd",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Phone = "(555) 987-6543"
            };
            Save(suppliers, supp1);
            Save(suppliers, supp2);

            return suppliers;
        }

        public void Remove(List<Supplier> entityList, Supplier ent)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Supplier> entityList, Supplier ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<Supplier> entityList, Supplier ent)
        {
            Supplier supplier = entityList.FirstOrDefault(c => c.SupplierID == ent.SupplierID);
            if (supplier != null)
            {
                supplier.ContactName = ent.ContactName;
                supplier.Phone = ent.Phone;
                Console.WriteLine("Supplier updated successfully");

                // Display updated
                FindAll(entityList);
            }
            else
            {
                Console.WriteLine("Supplier Not Found \n");
            }
        }
    }
}