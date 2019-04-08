using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(params T[] item);
        void Add(IEnumerable<T> item);
        void Delete(long id);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Update(params T[] item);
        void Update(IEnumerable<T> item);
    }
}
