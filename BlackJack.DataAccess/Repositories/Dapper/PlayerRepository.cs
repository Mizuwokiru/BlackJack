using System;
using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public override void Add(params Player[] items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Players (CreationTime, Name, Type) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @Name, @Type)", items);
        }

        public override void Add(IEnumerable<Player> items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Players (CreationTime, Name, Type) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @Name, @Type)", items);
        }

        public override void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM Players WHERE Id = @Id", new { Id = id });
        }

        public override Player Get(long id)
        {
            Player player = _dbConnection.QuerySingle<Player>("SELECT * FROM Players WHERE Id = @Id", new { Id = id });
            return player;
        }

        public override IEnumerable<Player> GetAll()
        {
            IEnumerable<Player> players = _dbConnection.Query<Player>("SELECT * FROM Players");
            return players;
        }

        public override void Update(params Player[] items)
        {
            _dbConnection.Execute("UPDATE Players SET Name = @Name, Type = @Type WHERE Id = @Id", items);
        }

        public override void Update(IEnumerable<Player> items)
        {
            _dbConnection.Execute("UPDATE Players SET Name = @Name, Type = @Type WHERE Id = @Id", items);
        }

        public int GetBotCount()
        {
            throw new System.NotImplementedException();
        }

        public List<Player> GetBots(int count)
        {
            throw new System.NotImplementedException();
        }

        public Player GetUser(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
