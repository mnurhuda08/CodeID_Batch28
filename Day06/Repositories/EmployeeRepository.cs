using Day06.AdoDb;
using Day06.Entity;
using Day06.Repository;
using Day06.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repositories
{
    internal class EmployeeRepository : RepositoryBase<Employees>
    {
        public EmployeeRepository(AdoDbContext adoDbContext) : base(adoDbContext)
        {
        }

        public override IEnumerable<Employees> FindAll()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };
            IEnumerator<Employees> dataSet = _adoDbContext.ExecuteReader<Employees>(model);

            _adoDbContext.Dispose();
            while (dataSet.MoveNext())
            {
                var employees = dataSet.Current;
                yield return employees;
            }
        }

        public async Task<IEnumerable<Employees>> FindAllAsync()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            var dataSet = _adoDbContext.ExecuteReader<Employees>(model);

            var employees = new List<Employees>();

            while (dataSet.MoveNext())
            {
                employees.Add(dataSet.Current);
            }
            _adoDbContext.Dispose();
            return employees;
        }

        public Employees FindById(object Id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees WHERE EmployeeID=@Id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value = Id
                    }
                }
            };
            IEnumerator<Employees> dataSet = _adoDbContext.ExecuteReader<Employees>(model);
            var employee = new Employees();

            while (dataSet.MoveNext())
            {
                employee = dataSet.Current;
            }
            _adoDbContext.Dispose();
            return employee;
        }

        public void Insert(Employees employee)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"INSERT INTO Employees  (LastName, FirstName,  Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath) VALUES (@lastName,@firstName, @title, @titleOfCourtesy, @birthDate, @hireDate, @address, @city, @region, @postalCode, @country, @homePhone, @extension, @notes, @reportTo, @photoPath);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                    ParameterName = "@Id",
                    DataType = DbType.Int64,
                    Value = employee.EmployeeID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@firstName",
                        DataType = DbType.String,
                        Value = employee.FirstName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@lastName",
                        DataType = DbType.String,
                        Value = employee.LastName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@title",
                        DataType = DbType.String,
                        Value = employee.Title
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@titleOfCourtesy",
                        DataType = DbType.String,
                        Value = employee.TitleOfCourtesy
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@birthDate",
                        DataType = DbType.DateTime,
                        Value = employee.BirthDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@hireDate",
                        DataType = DbType.DateTime,
                        Value = employee.HireDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@address",
                        DataType = DbType.String,
                        Value = employee.HireDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@city",
                        DataType = DbType.String,
                        Value = employee.City
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@region",
                        DataType = DbType.String,
                        Value = employee.Region
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@postalCode",
                        DataType = DbType.String,
                        Value = employee.PostalCode
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@country",
                        DataType = DbType.String,
                        Value = employee.Country
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@homePhone",
                        DataType = DbType.String,
                        Value = employee.HomePhone
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@extension",
                        DataType = DbType.String,
                        Value = employee.Extension
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@notes",
                        DataType = DbType.String,
                        Value = employee.Notes
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@reportTo",
                        DataType = DbType.Int64,
                        Value = employee.ReportsTo
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@photoPath",
                        DataType = DbType.String,
                        Value = employee.PhotoPath
                    },
                }
            };
            _adoDbContext.ExecuteNonQuery(model);
            _adoDbContext.Dispose();
        }

        public void Edit(Employees employee)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Employees SET FirstName=@firstName, LastName=@lastName WHERE employeeId=@id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@id",
                        DataType = DbType.Int64,
                        Value = employee.EmployeeID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@firstName",
                        DataType = DbType.String,
                        Value = employee.FirstName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@lastName",
                        DataType = DbType.String,
                        Value = employee.LastName
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
                CommandText = "DELETE FROM Employees WHERE EmployeeID=@Id",
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