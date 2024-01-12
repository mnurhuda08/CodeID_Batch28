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
    public class RepositoryEmployee : IRepositoryEmployee
    {
        private readonly AdoDbContext _adoContext;

        public RepositoryEmployee(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }

        public Employees Create(ref Employees employees)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"INSERT INTO Employees (LastName, FirstName,  Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath) VALUES (@lastName,@firstName, @title, @titleOfCourtesy, @birthDate, @hireDate, @address, @city, @region, @postalCode, @country, @homePhone, @extension, @notes, @reportTo, @photoPath);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel() {
                    ParameterName = "@Id",
                    DataType = DbType.Int64,
                    Value = employees.EmployeeID
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@firstName",
                        DataType = DbType.String,
                        Value = employees.FirstName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@lastName",
                        DataType = DbType.String,
                        Value = employees.LastName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@title",
                        DataType = DbType.String,
                        Value = employees.Title
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@titleOfCourtesy",
                        DataType = DbType.String,
                        Value = employees.TitleOfCourtesy
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@birthDate",
                        DataType = DbType.DateTime,
                        Value = employees.BirthDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@hireDate",
                        DataType = DbType.DateTime,
                        Value = employees.HireDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@address",
                        DataType = DbType.String,
                        Value = employees.HireDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@city",
                        DataType = DbType.String,
                        Value = employees.City
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@region",
                        DataType = DbType.String,
                        Value = employees.Region
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@postalCode",
                        DataType = DbType.String,
                        Value = employees.PostalCode
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@country",
                        DataType = DbType.String,
                        Value = employees.Country
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@homePhone",
                        DataType = DbType.String,
                        Value = employees.HomePhone
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@extension",
                        DataType = DbType.String,
                        Value = employees.Extension
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@notes",
                        DataType = DbType.String,
                        Value = employees.Notes
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@reportTo",
                        DataType = DbType.Int64,
                        Value = employees.ReportsTo
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@photoPath",
                        DataType = DbType.String,
                        Value = employees.PhotoPath
                    },
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return employees;
        }

        public void Delete(int id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "DELETE FROM Employees WHERE EmployeeID=@Id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value =id
                    }
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<Employees> FindAllEnumerable()
        {
            IEnumerator<Employees> dataSet = _adoContext
               .ExecuteReader<Employees>("select FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath from Employees");

            _adoContext.Dispose();

            while (dataSet.MoveNext())
            {
                var employee = dataSet.Current;
                yield return employee;
            }
        }

        public IEnumerator<Employees> FindAllEnumerator()
        {
            IEnumerator<Employees> dataSet = _adoContext
                .ExecuteReader<Employees>("SELECT FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees");

            _adoContext.Dispose();

            return dataSet;
        }

        public IEnumerable<Employees> FindEmployeeByFirstName(string firstName)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath FROM Employees WHERE FirstName like @firstName",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@firstName",
                        DataType = DbType.String,
                        Value = firstName
                    }
                }
            };

            var dataSet = _adoContext.ExecuteReader<Employees>(model);

            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                var employee = dataSet.Current;
                yield return employee;
            }

            _adoContext.Dispose();
        }

        public Employees FindByID(long id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath from Employees where EmployeeId=@Id;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value = id
                    }
                }
            };

            var dataSet = _adoContext.ExecuteReader<Employees>(model);

            var employee = new Employees();

            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                employee = dataSet.Current;
            }

            _adoContext.Dispose();

            return employee;
        }

        public Employees Update(Employees employees)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Employees SET firstName=@firstName WHERE employeeId=@Id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@firstName",
                        DataType = DbType.String,
                        Value = employees.FirstName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@Id",
                        DataType = DbType.Int64,
                        Value = employees.EmployeeID
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
            return employees;
        }
    }
}