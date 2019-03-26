using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GamePlayerRepository : BaseRepository<GamePlayer>, IGamePlayerRepository
    {
        public GamePlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<GamePlayer> GetPlayersByGame(int gameId) =>
            _dbContext.Set<GamePlayer>().Where(gamePlayer => gamePlayer.Game.Id == gameId);
    }
}
