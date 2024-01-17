/*using Day06.AdoDb;
using Day06.Entity;
using Day06.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal class EmployeeRepository : RepositoryBase, IRepositoryBase<Employees>
    {
        public EmployeeRepository()
        {
        }

        public EmployeeRepository(AdoDbContext adoDbContext) : base(adoDbContext)
        {
        }

        public IEnumerable<T> FindAll<T>()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            IEnumerator<T> dataSet = _adoDbContext.ExecuteReader<T>(model);

            while (dataSet.MoveNext())
            {
                var employee = dataSet.Current;
                yield return employee;
            }

            _adoDbContext.Dispose();
        }
    }
}*/