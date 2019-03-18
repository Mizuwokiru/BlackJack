using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GamePlayerRepository : BaseRepository<GamePlayer>, IGamePlayerRepository
    {
        public GamePlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<GamePlayer> GetGamePlayers(int gameId)
        {
            return Find(gamePlayer => gamePlayer.Game.Id == gameId);
        }
    }
}
