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
    internal class RepositoryCustomer : IRepository<Customers>
    {
        private readonly AdoDbContext _adoContext;

        public RepositoryCustomer(AdoDbContext adoDbContext)
        {
            _adoContext = adoDbContext;
        }

        public Customers Create(ref Customers customers)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES (@id, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone,@fax);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel() {
                    ParameterName = "@id",
                    DataType = DbType.String,
                    Value = customers.CustomerID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = customers.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = customers.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = customers.ContactTitle
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@address",
                        DataType = DbType.String,
                        Value = customers.Address
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@city",
                        DataType = DbType.String,
                        Value = customers.City
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@region",
                        DataType = DbType.String,
                        Value = customers.Region
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@postalCode",
                        DataType = DbType.String,
                        Value = customers.PostalCode
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@country",
                        DataType = DbType.String,
                        Value = customers.Country
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@phone",
                        DataType = DbType.String,
                        Value = customers.Phone
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@fax",
                        DataType = DbType.String,
                        Value = customers.Fax
                    },
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return customers;
        }

        public void Delete(object id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "DELETE FROM Customers WHERE CustomerID=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                        new SqlCommandParameterModel()
                        {
                            ParameterName = "@id",
                            DataType = DbType.String,
                            Value = id
                        }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<Customers> FindAllEnumerable()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Customers",
                CommandType = CommandType.Text,
            };

            IEnumerator<Customers> dataSet = _adoContext.ExecuteReader<Customers>(model.CommandText);

            _adoContext.Dispose();

            while (dataSet.MoveNext())
            {
                var customer = dataSet.Current;
                yield return customer;
            }
        }

        public IEnumerator<Customers> FindAllEnumerator()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Customers",
                CommandType = CommandType.Text,
            };

            IEnumerator<Customers> dataSet = _adoContext.ExecuteReader<Customers>(model.CommandText);
            _adoContext.Dispose();

            return dataSet;
        }

        public Customers FindByID(object id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Customers WHERE CustomerID = @id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@id",
                        DataType = DbType.String,
                        Value = id
                    }
                }
            };

            IEnumerator<Customers> dataSet = _adoContext.ExecuteReader<Customers>(model);

            var customer = new Customers();

            while (dataSet.MoveNext())
            {
                customer = dataSet.Current;
            }

            _adoContext.Dispose();
            return customer;
        }

        public IEnumerable<Customers> FindByName(string name)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Customers WHERE CompanyName LIKE @name OR ContactName LIKE @name",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@name",
                        DataType = DbType.String,
                        Value = name
                    }
                }
            };

            var dataSet = _adoContext.ExecuteReader<Customers>(model);

            while (dataSet.MoveNext())
            {
                var customer = dataSet.Current;
                yield return customer;
            }

            _adoContext.Dispose();
        }

        public Customers Update(Customers customers)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Customers SET ContactName = @contactName WHERE CustomerID=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = customers.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@id",
                        DataType = DbType.String,
                        Value = customers.CustomerID
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return customers;
        }
    }
}