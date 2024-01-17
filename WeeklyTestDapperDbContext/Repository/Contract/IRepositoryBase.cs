using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTestDapperDbContext.Repository.Contract
{
    internal interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();

        T FindByID(int id);

        T Create(ref T entity);

        T Update(T entity);

        void Delete(int id);
    }
}