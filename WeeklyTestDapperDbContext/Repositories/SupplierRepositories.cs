using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyTestDapperDbContext.DapperDb;
using WeeklyTestDapperDbContext.Entity;
using WeeklyTestDapperDbContext.Repository;

namespace WeeklyTestDapperDbContext.Repositories
{
    internal class SupplierRepositories : RepositoryBase<Supplier>
    {
        public SupplierRepositories(DapperDbContext dapperDbContext) : base(dapperDbContext)
        {
        }

        public override Supplier Create(ref Supplier entity)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "INSERT INTO Supplier (CompanyName, ContactName, ContactTitle, Phone) VALUES (@companyName,@contactName,@contactTitle,@phone);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@id",
                        DataType = DbType.Int64,
                        Value = entity.SupplierID
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = entity.CompanyName
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = entity.ContactName
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = entity.ContactTitle
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@phone",
                        DataType = DbType.String,
                        Value = entity.Phone,
                    }
                }
            };
            _dapperDbContext.ExecuteNonQuery(model);
            _dapperDbContext.Dispose();
            return entity;
        }

        public override void Delete(int id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "DELETE FROM Suppliers WHERE SupplierID=@id",
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
            _dapperDbContext.ExecuteNonQuery(model);
            _dapperDbContext.Dispose();
        }

        public override IEnumerable<Supplier> FindAll()
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = $"SELECT SupplierID, CompanyName, ContactName, Phone FROM Suppliers;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            IEnumerator<Supplier> dataSet = _dapperDbContext.ExecuteReader<Supplier>("SELECT SupplierID, CompanyName, ContactName, Phone FROM Suppliers");

            while (dataSet.MoveNext())
            {
                var supplier = dataSet.Current;
                yield return supplier;
            }
            _dapperDbContext.Dispose();
        }

        public override Supplier FindByID(int id)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "SELECT SupplierID, CompanyName, ContactName, Phone FROM Suppliers WHERE SupplierID=@id",
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
            IEnumerator<Supplier> dataSet = _dapperDbContext.ExecuteReader<Supplier>($"SELECT SupplierID, CompanyName, ContactName, Phone FROM Suppliers WHERE SupplierID={id}");
            var supplier = new Supplier();
            while (dataSet.MoveNext())
            {
                supplier = dataSet.Current;
            }
            _dapperDbContext.Dispose();
            return supplier;
        }

        public override Supplier Update(Supplier entity)
        {
            SqlCommandModel model = new SqlCommandModel
            {
                CommandText = "UPDATE Suppliers SET ContactName = @contactName WHERE SupplierID = @id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@id",
                        DataType = DbType.Int64,
                        Value = entity.SupplierID
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = entity.ContactName
                    },
                }
            };
            _dapperDbContext.ExecuteNonQuery(model);
            _dapperDbContext.Dispose();
            return entity;
        }
    }
}