using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbConnection _dbConnection;

        public BaseRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public abstract void Add(params T[] item);
        public abstract void Add(IEnumerable<T> item);
        public abstract void Delete(long id);
        public abstract T Get(long id);
        public abstract IEnumerable<T> GetAll();
        public abstract void Update(params T[] item);
        public abstract void Update(IEnumerable<T> item);
    }
}
