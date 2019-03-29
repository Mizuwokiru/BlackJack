﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Game> GetGames(int playerId)
        {
            return _dbContext.Set<Player>().Find(playerId).GamePlayers.Select(gamePlayer => gamePlayer.Game);
        }
    }
}
