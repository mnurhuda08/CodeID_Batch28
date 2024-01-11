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
            Employee emp1 = new Employee(1, "Ahmad", "Solihul", "Sales", "Mr.", new DateTime(1998, 7, 12), new DateTime(2024, 1, 10), "Jl Kaliurang", "Sleman", "DIY", "56281", "Indonesia", "+26762135921", 3214, "ad_biru.png", "Nothingness", null, "ad_biru.png");

            Employee emp2 = new Employee(2, "Rahmad", "Darma", "Admin", "Mr.", new DateTime(1998, 5, 12), new DateTime(2024, 1, 10), "Jl Gebang", "Bantul", "DIY", "56281", "Indonesia", " + 26762135921", 3214, "rd_biru.png", "Nothingness", null, "rd_biru.png");

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