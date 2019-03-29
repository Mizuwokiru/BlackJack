using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly GameDbContext _dbContext;

        public BaseRepository(DbConnection dbConnection)
        {
            _dbContext = new GameDbContext(dbConnection);
        }

        public T Get(int id) => _dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => _dbContext.Set<T>();

        public void Add(params T[] item)
        {
            _dbContext.Set<T>().AddRange(item);
            _dbContext.SaveChanges();
        }

        public void Add(IEnumerable<T> item)
        {
            Add(item);
        }

        public void Update(params T[] item)
        {
            _dbContext.Set<T>().UpdateRange(item);
            _dbContext.SaveChanges();
        }

        public void Update(IEnumerable<T> item)
        {
            Add(item);
        }

        public void Delete(int id)
        {
            T obj = _dbContext.Set<T>().Find(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
            _dbContext.SaveChanges();
        }
    }
}
