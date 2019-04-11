using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbConnection _dbConnection;

        public BaseRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(params T[] items)
        {
            Add(items.AsEnumerable());
        }

        public void Add(IEnumerable<T> items)
        {
            IEnumerable<string> propertyNames = GetPropertyNames();
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO {nameof(T)}s (CreationTime, {
                string.Join(", ", propertyNames)}) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', {
                string.Join(", ", propertyNames.Select(propertyName => $"@{propertyName}"))})", items);
        }

        public void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM {nameof(T)}s WHERE Id = @Id", new { Id = id });
        }

        public T Get(long id)
        {
            T record = _dbConnection.QuerySingle<T>($"SELECT * FROM {nameof(T)}s WHERE Id = @Id", new { Id = id });
            return record;
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> records = _dbConnection.Query<T>($"SELECT * FROM {nameof(T)}s");
            return records;
        }

        public void Update(params T[] items)
        {
            Update(items.AsEnumerable());
        }

        public void Update(IEnumerable<T> items)
        {
            IEnumerable<string> propertyNames = GetPropertyNames();
            _dbConnection.Execute($@"UPDATE {nameof(T)}s SET {
                string.Join(", ", propertyNames.Select(propertyName => $"{propertyName} = @{propertyName}"))} WHERE Id = @Id", items);
        }

        private IEnumerable<string> GetPropertyNames()
        {
            IEnumerable<string> propertyNames = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | ~BindingFlags.FlattenHierarchy)
                .Where(property => !property.GetGetMethod().IsVirtual)
                .Select(property => property.Name);
            return propertyNames;
        }
    }
}
