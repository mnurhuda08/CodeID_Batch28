using Day06.AdoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository.Contract
{
    internal interface IRepositoryBase<T>
    {
        /*IEnumerator<T> FindAll(string sql);*/

        IEnumerable<T> FindAll();

        IEnumerable<T> FindByID(object Id);

        T Create(T entity);

        T Update(T entity);

        void Delete(object Id);
    }
}