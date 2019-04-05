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

        public async Task<List<Round>> GetLastRounds(long gameId)
        {
            DateTime lastRoundTime = _dbContext.Rounds
                .Select(round => round.CreationTime)
                .Max();
            Task<List<Round>> lastRounds = _dbContext.Rounds
                .Where(lastRound => lastRound.CreationTime == lastRoundTime)
                .ToListAsync();
            return await lastRounds;
        }

        public async Task<Round> GetLastRound(long gameId, long playerId)
        {
            List<Round> lastRounds = await GetLastRounds(gameId);
            Round lastRound = lastRounds.FirstOrDefault(round => round.PlayerId == playerId);
            return lastRound;
        }

        public async Task<IEnumerable<IGrouping<DateTime, Round>>> GetRounds(long gameId)
        {
            Task<List<IGrouping<DateTime, Round>>> rounds = _dbContext.Rounds
                .GroupBy(round => round.CreationTime)
                .ToListAsync();
            return await rounds;
        }
    }
}
