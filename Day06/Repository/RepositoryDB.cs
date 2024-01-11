using Day06.AdoDb;
using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    public class RepositoryDB<T> : IRepository<T>
    {
        private readonly AdoDbContext _adoContext;

        public RepositoryDB(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }

        public IEnumerator<T> FindAllEnumerator()
        {
            IEnumerator<T> dataSet = _adoContext.ExecuteReader<T>("SELECT * FROM " + typeof(T).Name);
            _adoContext.Dispose();

            return dataSet;
        }

        public IEnumerable<T> FindAllEnumerable()
        {
            IEnumerator<T> dataSet = _adoContext.ExecuteReader<T>("SELECT * FROM " + typeof(T).Name);
            Console.WriteLine(typeof(T).Name);
            _adoContext.Dispose();
            while (dataSet.MoveNext())
            {
                var employee = dataSet.Current;
                yield return employee;
            }
        }

        /* public IEnumerator<Employees> FindAll()
         {
             IEnumerator<Employees> dataSet = _adoContext.ExecuteReader<Employees>("SELECT * FROM Employees");
             _adoContext.Dispose();
             return dataSet;
         }

         public IEnumerable<Employees> FindAllEmployee()
         {
             IEnumerator<Employees> dataSet = _adoContext.ExecuteReader<Employees>("SELECT * FROM Employees");
             _adoContext.Dispose();
             while (dataSet.MoveNext())
             {
                 var employee = dataSet.Current;
                 yield return employee;
             }
         }*/
    }
}