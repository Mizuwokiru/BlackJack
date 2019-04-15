using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameDbContext dbContext) : base(dbContext)
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

        public IEnumerable<HistoryGameInfoModel> GetGamesHistory(long userId)
        {
            IEnumerable<HistoryGameInfoModel> userGames = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Select(round => round.Game)
                .Distinct()
                .GroupJoin(
                    _dbContext.Rounds,
                    game => game.Id,
                    round => round.GameId,
                    (game, rounds) => new HistoryGameInfoModel
                    {
                        PlayerCount = rounds.GroupBy(round => round.PlayerId).Count(),
                        RoundCount = rounds.Count(round => round.PlayerId == userId),
                        CreationTime = game.CreationTime.Value
                    })
                .OrderByDescending(gameInfo => gameInfo.CreationTime);
            return userGames;
        }
    }
}
