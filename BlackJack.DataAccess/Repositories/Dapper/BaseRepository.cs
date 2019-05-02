using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly string _connectionString;

        public BaseRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.GameConnectionString;
        }

        public void Add(params T[] items)
        {
            Add(items.AsEnumerable());
        }

        public void Add(IEnumerable<T> items)
        {
            IEnumerable<string> propertyNames = GetPropertyNames();
            var now = DateTime.Now;
            string sqlQuery =
                $@"INSERT INTO {typeof(T).Name}s (CreationTime, {
                string.Join(", ", propertyNames)})
                OUTPUT INSERTED.Id AS Id
                VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', {
                string.Join(", ", propertyNames.Select(propertyName => $"@{propertyName}"))})";
            using (var connection = new SqlConnection(_connectionString))
            {
                foreach (var item in items)
                {
                    long id = connection.Query<long>(sqlQuery, item).First();
                    item.Id = id;
                    item.CreationTime = now;
                }
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute($"DELETE FROM {typeof(T).Name}s WHERE Id = @Id", new { Id = id });
            }
        }

        public T Get(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                T record = connection.QuerySingle<T>($"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id", new { Id = id });
                return record;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<T> records = connection.Query<T>($"SELECT * FROM {typeof(T).Name}s");
                return records;
            }
        }

        public void Update(params T[] items)
        {
            Update(items.AsEnumerable());
        }

        public void Update(IEnumerable<T> items)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<string> propertyNames = GetPropertyNames();
                connection.Execute($@"UPDATE {typeof(T).Name}s SET {
                    string.Join(", ", propertyNames.Select(propertyName => $"{propertyName} = @{propertyName}"))} WHERE Id = @Id", items);
            }
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
