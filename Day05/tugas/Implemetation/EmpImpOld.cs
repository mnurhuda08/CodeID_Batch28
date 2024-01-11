using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    internal class EmpImpOld : IRepositoryMockup<EmployeeOld>
    {
        public void FindAll(List<EmployeeOld> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public EmployeeOld FindByID(List<EmployeeOld> entityList, EmployeeOld ent)
        {
            // Get EmployeeOlds list
            List<EmployeeOld> EmployeeOlds = entityList;

            // Find EmployeeOld by ID
            EmployeeOld foundEmp = EmployeeOlds.Find(e => e.EmployeeID == ent.EmployeeID);

            if (foundEmp == null)
            {
                Console.WriteLine("EmployeeOld not found");
            }

            return foundEmp;
        }

        public List<EmployeeOld> InitListData()
        {
            List<EmployeeOld> EmployeeOlds = new List<EmployeeOld>();
            EmployeeOld emp1 = new EmployeeOld
            {
                EmployeeID = 1,
                FirstName = "Doe",
                LastName = "John",
                Title = "Sales Manager",
                TitleOfCourtesy = "Mr.",
                BirthDate = new DateTime(1980, 10, 5),
                HireDate = new DateTime(2005, 3, 15),
                Address = "1234 Main St",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Extension = 1234,
                PhotoPath = "john_smith.png",
                ReportTo = null
            };
            EmployeeOld emp2 = new EmployeeOld
            {
                EmployeeID = 2,
                FirstName = "John",
                LastName = "Doe",
                Title = "Salesperson",
                TitleOfCourtesy = "Ms.",
                BirthDate = new DateTime(1990, 11, 12),
                HireDate = new DateTime(2015, 6, 1),
                Address = "1234 Oak Ave",
                City = "Anytown",
                Region = "CA",
                PostalCode = "12345",
                Country = "USA",
                Extension = 4567,
                PhotoPath = "jane_doe.png",
                ReportTo = 1
            };

            Save(EmployeeOlds, emp1);
            Save(EmployeeOlds, emp2);

            return EmployeeOlds;
        }

        public void Remove(List<EmployeeOld> entityList, EmployeeOld ent)
        {
            entityList.Remove(ent);
        }

        public void Save(List<EmployeeOld> entityList, EmployeeOld ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<EmployeeOld> entityList, EmployeeOld ent)
        {
            EmployeeOld EmployeeOld = entityList.FirstOrDefault(e => e.EmployeeID == ent.EmployeeID);
            if (EmployeeOld != null)
            {
                EmployeeOld.FirstName = ent.FirstName;
                EmployeeOld.LastName = ent.LastName;
                EmployeeOld.Title = ent.Title;
                Console.WriteLine("EmployeeOld updated successfully");

                // Display updated
                FindByID(entityList, EmployeeOld);
            }
            else
            {
                Console.WriteLine("EmployeeOld Not Found \n");
            }
        }
    }
}