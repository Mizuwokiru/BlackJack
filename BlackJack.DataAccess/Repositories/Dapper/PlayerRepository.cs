using System;
using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IOptions<DbSettingsOptions> options) : base(options)
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
