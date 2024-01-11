using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    public class SupplierImpOld : IRepositoryMockup<SupplierOld>
    {
        public void FindAll(List<SupplierOld> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public SupplierOld FindByID(List<SupplierOld> entityList, SupplierOld ent)
        {
            // Get Supplier list
            List<SupplierOld> suppliers = entityList;

            // Find supplier by ID
            SupplierOld foundSupp = suppliers.Find(s => s.SupplierID == ent.SupplierID);

            if (foundSupp == null)
            {
                Console.WriteLine("Supplier not found");
            }

            return foundSupp;
        }

        public List<SupplierOld> InitListData()
        {
            List<SupplierOld> suppliers = new List<SupplierOld>();
            SupplierOld supp1 = new SupplierOld
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
            SupplierOld supp2 = new SupplierOld
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

        public void Remove(List<SupplierOld> entityList, SupplierOld ent)
        {
            throw new NotImplementedException();
        }

        public void Save(List<SupplierOld> entityList, SupplierOld ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<SupplierOld> entityList, SupplierOld ent)
        {
            SupplierOld supplier = entityList.FirstOrDefault(c => c.SupplierID == ent.SupplierID);
            if (supplier != null)
            {
                supplier.ContactName = ent.ContactName;
                supplier.Phone = ent.Phone;

                // Display updated
                FindByID(entityList, supplier);
                Console.WriteLine("Supplier updated successfully");
            }
            else
            {
                Console.WriteLine("Supplier Not Found \n");
            }
        }
    }
}