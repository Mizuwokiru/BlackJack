using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Round GetLastRound(long userId)
        {
            Round lastRound = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .OrderByDescending(round => round.CreationTime)
                .FirstOrDefault();
            return lastRound;
        }

        public List<Round> GetLastRounds(long gameId)
        {
            DateTime? lastCreationTime = _dbContext.Rounds.Max(round => round.CreationTime);
            List<Round> lastRounds = _dbContext.Rounds
                .Where(round => round.GameId == gameId && round.CreationTime == lastCreationTime)
                .ToList();
            return lastRounds;
        }
    }
}
