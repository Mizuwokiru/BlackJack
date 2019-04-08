using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
        
        public Game GetUnfinishedGame(long userId)
        {
            Game game = _dbContext.Rounds
                .Where(round => round.PlayerId == userId && !round.Game.IsFinished)
                .FirstOrDefault()?.Game;
            return game;
        }
    }
}
