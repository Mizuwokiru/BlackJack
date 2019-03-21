using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class GamePlayerRepository : BaseRepository<GamePlayer>, IGamePlayerRepository
    {
        public GamePlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<GamePlayer> GetGamePlayers(int gameId) =>
            _dbContext.Set<GamePlayer>().Where(gamePlayer => gamePlayer.Game.Id == gameId);
    }
}
