using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public List<Round> GetLastRounds(long gameId)
        {
            if (_dbContext.Rounds.Count() == 0)
            {
                return new List<Round>();
            }
            DateTime lastRoundTime = _dbContext.Rounds
                .Select(round => round.CreationTime)
                .Max();
            List<Round> lastRounds = _dbContext.Rounds
                .Where(lastRound => lastRound.CreationTime == lastRoundTime)
                .ToList();
            return lastRounds;
        }

        public Round GetLastRound(long gameId, long playerId)
        {
            List<Round> lastRounds = GetLastRounds(gameId);
            Round lastRound = lastRounds.FirstOrDefault(round => round.PlayerId == playerId);
            return lastRound;
        }

        public IEnumerable<IGrouping<DateTime, Round>> GetRounds(long gameId)
        {
            IEnumerable<IGrouping<DateTime, Round>> rounds = _dbContext.Rounds
                .GroupBy(round => round.CreationTime);
            return rounds;
        }
    }
}
