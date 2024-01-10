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
            Supplier supp1 = new Supplier(1, "ABC Corp", "Jane Doe", "Purchasing Manager", "123 Maple St", "Anytown", "CA", "12345", "USA", "(555) 123-4567", "(555) 123-4568", "www.abc-corp.com"
           );
            Supplier supp2 = new Supplier(2, "Acme Ltd", "John Smith", "Sales Agent", "456 Elm Rd", "Anytown", "CA", "12345", "USA", "(555) 987-6543", null, null
            );
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