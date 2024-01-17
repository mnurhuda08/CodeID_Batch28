using Day06.AdoDb;
using Day06.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AdoDbContext _adoDbContext;

        protected RepositoryBase(AdoDbContext adoDbContext)
        {
            _adoDbContext = adoDbContext;
        }

        public virtual T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindByID(object Id)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}