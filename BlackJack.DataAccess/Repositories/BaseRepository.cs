﻿using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Func<T, bool> findFunc)
        {
            return _dbContext.Set<T>().Where(findFunc);
        }

        public void Create(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T obj = _dbContext.Set<T>().Find(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
        }
    }
}