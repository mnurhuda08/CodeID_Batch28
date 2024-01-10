using Day05.tugas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Repository
{
    public interface IRepositoryMockup<T>
    {
        List<T> InitListData();

        public void Save(List<T> entityList, T ent);

        public void Update(List<T> entityList, T ent);

        public void Remove(List<T> entityList, T ent);

        public void FindAll(List<T> entityList);

        public T FindByID(List<T> entityList, T ent);
    }
}