﻿using Day06.Entity;
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

        Task<IEnumerable<T>> FindAllTaskEnumerableAsync(); // alternate

        IAsyncEnumerable<T> FindAllEnumerableAsync();

        T FindByID(object id);

        IEnumerable<T> FindByName(string name);

        T Create(ref T item);

        T Update(T item);

        void Delete(object id);
    }
}