using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(params T[] item);
        void Add(IEnumerable<T> item);
        void Update(params T[] item);
        void Update(IEnumerable<T> item);
        void Delete(int id);
    }
}
