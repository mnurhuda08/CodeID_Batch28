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

        public Suppliers Create(ref Suppliers suppliers)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"INSERT INTO Suppliers (SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) VALUES (@id, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone,@fax, @homePage);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel() {
                    ParameterName = "@id",
                    DataType = DbType.Int64,
                    Value = suppliers.SupplierID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = suppliers.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = suppliers.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = suppliers.ContactTitle
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@address",
                        DataType = DbType.String,
                        Value = suppliers.Address
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@city",
                        DataType = DbType.String,
                        Value = suppliers.City
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@region",
                        DataType = DbType.String,
                        Value = suppliers.Region
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@postalCode",
                        DataType = DbType.String,
                        Value = suppliers.PostalCode
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@country",
                        DataType = DbType.String,
                        Value = suppliers.Country
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@phone",
                        DataType = DbType.String,
                        Value = suppliers.Phone
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@fax",
                        DataType = DbType.String,
                        Value = suppliers.Fax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@homePage",
                        DataType = DbType.String,
                        Value = suppliers.HomePage
                    },
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return suppliers;
        }

        public void Delete(object id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "DELETE FROM Suppliers WHERE SupplierID=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
               {
                        new SqlCommandParameterModel()
                        {
                            ParameterName = "@id",
                            DataType = DbType.Int64,
                            Value = id
                        }
               }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<Suppliers> FindAllEnumerable()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Suppliers",
                CommandType = CommandType.Text,
            };

            IEnumerator<Suppliers> dataSet = _adoContext.ExecuteReader<Suppliers>(model.CommandText);

            while (dataSet.MoveNext())
            {
                var supplier = dataSet.Current;
                yield return supplier;
            }
        }

        public IEnumerator<Suppliers> FindAllEnumerator()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Suppliers",
                CommandType = CommandType.Text,
            };

            IEnumerator<Suppliers> dataSet = _adoContext.ExecuteReader<Suppliers>(model.CommandText);
            _adoContext.Dispose();

            return dataSet;
        }

        public Suppliers FindByID(object id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Suppliers WHERE CustomerID = @id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@id",
                        DataType = DbType.Int64,
                        Value = id
                    }
                }
            };

            IEnumerator<Suppliers> dataSet = _adoContext.ExecuteReader<Suppliers>(model);

            var supplier = new Suppliers();

            while (dataSet.MoveNext())
            {
                supplier = dataSet.Current;
            }

            _adoContext.Dispose();
            return supplier;
        }

        public IEnumerable<Suppliers> FindByName(string name)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT * FROM Suppliers WHERE CompanyName LIKE @name OR ContactName LIKE @name",
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

            var dataSet = _adoContext.ExecuteReader<Suppliers>(model);

            while (dataSet.MoveNext())
            {
                var supplier = dataSet.Current;
                yield return supplier;
            }

            _adoContext.Dispose();
        }

        public Suppliers Update(Suppliers suppliers)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Suppliers SET ContactName = @contactName WHERE CustomerID=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = suppliers.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@id",
                        DataType = DbType.String,
                        Value = suppliers.SupplierID
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return suppliers;
        }
    }
}