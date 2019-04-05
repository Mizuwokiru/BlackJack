using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly GameDbContext _dbContext;

        public BaseRepository(DbConnection dbConnection)
        {
            _dbContext = new GameDbContext(dbConnection);
        }

        public void Add(params T[] item)
        {
            _dbContext.Set<T>().AddRange(item);
            _dbContext.SaveChanges();
        }

        public void Add(IEnumerable<T> item)
        {
            _dbContext.Set<T>().AddRange(item);
        }

        public void Delete(long id)
        {
            T obj = _dbContext.Set<T>().Find(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
        }

        public async Task<T> Get(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(params T[] item)
        {
            _dbContext.Set<T>().UpdateRange(item);
        }

        public void Update(IEnumerable<T> item)
        {
            _dbContext.Set<T>().UpdateRange(item);
        }
    }
}
