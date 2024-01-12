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
    public class RepositorySupplier : IRepository<Suppliers>
    {
        private readonly AdoDbContext _adoContext;

        public RepositorySupplier(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }

        public IEnumerable<Suppliers> FindAllEnumerable()
        {
            IEnumerator<Suppliers> dataSet = _adoContext
              .ExecuteReader<Suppliers>("SELECT * FROM Suppliers");

            _adoContext.Dispose();

            while (dataSet.MoveNext())
            {
                var supplier = dataSet.Current;
                yield return supplier;
            }
        }

        public IEnumerator<Suppliers> FindAllEnumerator()
        {
            IEnumerator<Suppliers> dataSet = _adoContext
               .ExecuteReader<Suppliers>("SELECT * FROM Suppliers");

            _adoContext.Dispose();

            return dataSet;
        }

        public Suppliers FindByID(long id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Suppliers WHERE SupllierId=@Id;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value = id
                    }
                }
            };

            var dataSet = _adoContext.ExecuteReader<Suppliers>(model);

            var supplier = new Suppliers();

            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                supplier = dataSet.Current;
            }

            _adoContext.Dispose();

            return supplier;
        }
    }
}