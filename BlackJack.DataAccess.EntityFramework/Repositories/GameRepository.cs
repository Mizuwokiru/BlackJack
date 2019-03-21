using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Game GetGameOfGamePlayer(int gamePlayerId) => _dbContext.Set<GamePlayer>().Find(gamePlayerId).Game;

        public Game GetGameOfRound(int roundId) => _dbContext.Set<Round>().Find(roundId).Game;
    }
}
