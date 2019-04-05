using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<bool> CanToContinueGame(long userId)
        {
            Game game = await GetUnfinishedGame(userId);
            return game != null;
        }

        public async Task<Game> GetUnfinishedGame(long userId)
        {
            Task<Game> unfinishedGame = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Select(round => round.Game)
                .Where(game => !game.IsFinished)
                .FirstOrDefaultAsync();
            return await unfinishedGame;
        }
    }
}
