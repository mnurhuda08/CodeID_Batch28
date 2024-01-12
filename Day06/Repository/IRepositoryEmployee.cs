using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal interface IRepositoryEmployee
    {
        IEnumerator<Employees> FindAllEnumerator();

        IEnumerable<Employees> FindAllEnumerable();

        Employees FindByID(long id);

        IEnumerable<Employees> FindEmployeeByFirstName(string firstName);

        Employees Create(ref Employees employees);

        Employees Update(Employees employees);

        void Delete(int id);
    }
}