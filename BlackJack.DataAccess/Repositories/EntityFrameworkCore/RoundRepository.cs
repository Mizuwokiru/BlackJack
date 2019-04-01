using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Round> GetLastRoundsByGame(int gameId)
        {
            var roundsByGame = _dbContext.Rounds
                .Where(round => round.GameId == gameId);
            return roundsByGame
                .Where(round => round.CreationTime == roundsByGame.Select(r => r.CreationTime).Max());
        }
    }
}
