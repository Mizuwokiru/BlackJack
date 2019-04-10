using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
            Game unfinishedGame = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Join(
                    _dbContext.Games,
                    round => round.GameId,
                    game => game.Id,
                    (round, game) => game)
                .Where(game => !game.IsFinished)
                .FirstOrDefault();
            return unfinishedGame;
        }

        public int GetPlayerCount(long gameId)
        {
            IQueryable<Round> roundsByGame = _dbContext.Rounds
                .Where(round => round.GameId == gameId);
            DateTime? someDate = roundsByGame
                .Select(round => round.CreationTime)
                .FirstOrDefault();
            int playerCount = roundsByGame
                .Where(round => round.CreationTime == someDate)
                .Count();
            return playerCount;
        }
    }
}
