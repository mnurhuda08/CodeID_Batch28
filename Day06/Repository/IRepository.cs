using Day06.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal interface IRepository<T>
    {
        IEnumerator<T> FindAllEnumerator();

        IEnumerable<T> FindAllEnumerable();
    }
}