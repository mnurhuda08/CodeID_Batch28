using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repositories
{
    internal interface IRepository<T>
    {
        IEnumerable<T> FindAll();

        Task<IEnumerable<T>> FindAllAsync();

        T FindById(object Id);

        void Insert(T entity);

        void Edit(T entity);

        void Remove(object Id);
    }
}