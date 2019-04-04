using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System;
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

        public Round GetLastRound(long gameId)
        {
            Round lastRound = GetLastRounds(gameId).FirstOrDefault();
            return lastRound;
        }

        public IEnumerable<Round> GetLastRounds(long gameId)
        {
            IEnumerable<Round> rounds = GetRounds(gameId);
            DateTime lastTime = rounds.Select(round => round.CreationTime).Max();
            IEnumerable<Round> lastRounds = rounds.Where(round => round.CreationTime == lastTime);
            return lastRounds;
        }

        public IEnumerable<Round> GetRounds(long gameId)
        {
            IEnumerable<Round> rounds = _dbContext.Rounds
                .Where(round => round.GameId == gameId);
            return rounds;
        }
    }
}
