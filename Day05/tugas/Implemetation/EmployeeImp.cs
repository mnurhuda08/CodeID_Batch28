using Day05.tugas.Entities;
using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Implemetation
{
    public class EmployeeImp : IRepositoryMockup<Employee>
    {
        public void FindAll(List<Employee> entityList)
        {
            foreach (var item in entityList)
            {
                Console.WriteLine(item);
            }
        }

        public Employee FindByID(List<Employee> entityList, Employee ent)
        {
            // Get employees list
            List<Employee> employees = entityList;

            // Find employee by ID
            Employee foundEmp = employees.Find(e => e.EmployeeID == ent.EmployeeID);

            if (foundEmp == null)
            {
                Console.WriteLine("Employee not found");
            }

            return foundEmp;
        }

        public List<Employee> InitListData()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee
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
                HomePhone = "+231276213",
                Extension = 1234,
                PhotoPath = "john_smith.png",
                ReportTo = null
            };
            Employee emp2 = new Employee
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
                HomePhone = "+231276213",
                Extension = 4567,
                PhotoPath = "jane_doe.png",
                ReportTo = 1
            };

            Save(employees, emp1);
            Save(employees, emp2);

            return employees;
        }

        public void Remove(List<Employee> entityList, Employee ent)
        {
            entityList.Remove(ent);
        }

        public void Save(List<Employee> entityList, Employee ent)
        {
            entityList.Add(ent);
        }

        public void Update(List<Employee> entityList, Employee ent)
        {
            Employee employee = entityList.FirstOrDefault(e => e.EmployeeID == ent.EmployeeID);
            if (employee != null)
            {
                employee.FirstName = ent.FirstName;
                employee.LastName = ent.LastName;
                employee.Title = ent.Title;
                Console.WriteLine("Employee updated successfully");

                // Display updated
                FindByID(entityList, employee);
            }
            else
            {
                Console.WriteLine("Employee Not Found \n");
            }
        }
    }
}