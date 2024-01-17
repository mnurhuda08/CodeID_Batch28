using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyTestDapperDbContext.DapperDb;
using WeeklyTestDapperDbContext.Repository.Contract;

namespace WeeklyTestDapperDbContext.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DapperDbContext _dapperDbContext;

        protected RepositoryBase(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public virtual T Create(ref T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual T FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}