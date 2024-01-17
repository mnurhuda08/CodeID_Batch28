using Day06.AdoDb;
using Day06.Entity;
using Day06.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repositories
{
    internal class CustomerRepository : RepositoryBase<Customers>, IRepository<Customers>
    {
        public CustomerRepository(AdoDbContext adoDbContext) : base(adoDbContext)
        {
        }

        public void Edit(Customers customer)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Customers SET ContactName = @contactName WHERE CustomerID=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@id",
                        DataType = DbType.String,
                        Value = customer.CustomerID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = customer.ContactName
                    },
                }
            };

            _adoDbContext.ExecuteNonQuery(model);
            _adoDbContext.Dispose();
        }

        public IEnumerable<Customers> FindAll()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Customers",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };
            IEnumerator<Customers> dataSet = _adoDbContext.ExecuteReader<Customers>(model);

            _adoDbContext.Dispose();
            while (dataSet.MoveNext())
            {
                var Customers = dataSet.Current;
                yield return Customers;
            }
        }

        public async Task<IEnumerable<Customers>> FindAllAsync()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT * FROM Customers",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            IAsyncEnumerator<Customers> dataSet = _adoDbContext.ExecuteReaderAsync<Customers>(model);

            var customers = new List<Customers>();

            while (await dataSet.MoveNextAsync())
            {
                customers.Add(dataSet.Current);
            }
            _adoDbContext.Dispose();
            return customers;
        }

        public Customers FindById(object Id)
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
                        Value = Id
                    }
                }
            };

            IEnumerator<Customers> dataSet = _adoDbContext.ExecuteReader<Customers>(model);

            var customer = new Customers();

            while (dataSet.MoveNext())
            {
                customer = dataSet.Current;
            }

            _adoDbContext.Dispose(); ;
            return customer;
        }

        public void Insert(Customers customer)
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
                    Value = customer.CustomerID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = customer.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = customer.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = customer.ContactTitle
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@address",
                        DataType = DbType.String,
                        Value = customer.Address
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@city",
                        DataType = DbType.String,
                        Value = customer.City
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@region",
                        DataType = DbType.String,
                        Value = customer.Region
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@postalCode",
                        DataType = DbType.String,
                        Value = customer.PostalCode
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@country",
                        DataType = DbType.String,
                        Value = customer.Country
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@phone",
                        DataType = DbType.String,
                        Value = customer.Phone
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@fax",
                        DataType = DbType.String,
                        Value = customer.Fax
                    },
                 }
            };
            _adoDbContext.ExecuteNonQuery(model);
            _adoDbContext.Dispose();
        }

        public void Remove(object Id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "DELETE FROM Customers WHERE CustomerID=@Id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel()
                    {
                        ParameterName="@Id",
                        DataType = DbType.Int64,
                        Value = Id
                    }
                }
            };
            _adoDbContext.ExecuteNonQuery(model);
            _adoDbContext.Dispose();
        }
    }
}