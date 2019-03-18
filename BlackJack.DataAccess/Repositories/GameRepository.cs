using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Game GetGameOfGamePlayer(int gamePlayerId)
        {
            return _dbContext.Set<GamePlayer>().Find(gamePlayerId).Game;
        }

        public Game GetGameOfRound(int roundId)
        {
            return _dbContext.Set<Round>().Find(roundId).Game;
        }
    }
}
