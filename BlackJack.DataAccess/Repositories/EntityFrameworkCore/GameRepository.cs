﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;
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
                    _dbContext.Games.Where(game => !game.IsFinished),
                    round => round.GameId,
                    game => game.Id,
                    (round, game) => game)
                .FirstOrDefault();
            return unfinishedGame;
        }

        public int GetPlayerCount(long gameId)
        {
            int playerCount = _dbContext.Rounds
                .Where(round => round.GameId == gameId && round.CreationTime == _dbContext.Rounds
                    .Where(someRound => someRound.GameId == gameId)
                    .Select(someRound => someRound.CreationTime)
                    .FirstOrDefault())
                .Count();
            return playerCount;
        }

        public IEnumerable<GamesHistoryInfoModel> GetGamesHistory(long userId)
        {
            IEnumerable<GamesHistoryInfoModel> userGames = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Select(round => round.Game)
                .Distinct()
                .GroupJoin(
                    _dbContext.Rounds,
                    game => game.Id,
                    round => round.GameId,
                    (game, rounds) => new GamesHistoryInfoModel
                    {
                        PlayerCount = rounds.GroupBy(round => round.PlayerId).Count(),
                        RoundCount = rounds.Count(round => round.PlayerId == userId),
                        CreationTime = game.CreationTime.Value
                    })
                .OrderByDescending(gameInfo => gameInfo.CreationTime);
            return userGames;
        }

        public long GetGameIdBySkipCount(long userId, int gameSkipCount)
        {
            long gameId = _dbContext.Games
                .GroupJoin(
                    _dbContext.Rounds
                        .Where(round => round.PlayerId == userId),
                    game => game.Id,
                    round => round.GameId,
                    (game, rounds) => new { game.Id, game.CreationTime })
                .OrderByDescending(game => game.CreationTime)
                .Skip(gameSkipCount)
                .First()
                .Id;
            return gameId;
        }
    }
}
