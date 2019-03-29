using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GamePlayerRepository : BaseRepository<GamePlayer>, IGamePlayerRepository
    {
        public GamePlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<GamePlayer> GetGamePlayers(int gameId)
        {
            return _dbContext.Set<Game>().Find(gameId).Players;
        }
    }
}
