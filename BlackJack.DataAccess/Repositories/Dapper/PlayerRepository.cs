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
