using Day06.AdoDb;
using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    public class RepositoryCustomer : IRepository<Customers>
    {
        private readonly AdoDbContext _adoContext;

        public RepositoryCustomer(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }

        public IEnumerable<Customers> FindAllEnumerable()
        {
            IEnumerator<Customers> dataSet = _adoContext
              .ExecuteReader<Customers>("SELECT * FROM Customers");

            _adoContext.Dispose();

            while (dataSet.MoveNext())
            {
                var customer = dataSet.Current;
                yield return customer;
            }
        }

        public IEnumerator<Customers> FindAllEnumerator()
        {
            IEnumerator<Customers> dataSet = _adoContext
               .ExecuteReader<Customers>("SELECT * FROM Customers");

            _adoContext.Dispose();

            return dataSet;
        }

        public Customers FindByID(long id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Customers WHERE Customers=@Id;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value = id
                    }
                }
            };

            var dataSet = _adoContext.ExecuteReader<Customers>(model);

            var customer = new Customers();

            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                customer = dataSet.Current;
            }

            _adoContext.Dispose();

            return customer;
        }
    }
}