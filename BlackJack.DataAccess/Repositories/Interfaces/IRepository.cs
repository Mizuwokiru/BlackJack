using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(params T[] item);
        void Add(IEnumerable<T> item);
        void Delete(long id);
        Task<T> Get(long id);
        Task<IEnumerable<T>> GetAll();
        void Update(params T[] item);
        void Update(IEnumerable<T> item);
    }
}
