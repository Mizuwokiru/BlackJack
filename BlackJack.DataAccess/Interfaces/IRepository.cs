using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> findFunc);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
