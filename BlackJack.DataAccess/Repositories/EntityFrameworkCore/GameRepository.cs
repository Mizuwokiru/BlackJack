using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public int GetBotCount(long gameId)
        {
            int botCount = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.GameId == gameId)
                .Select(roundPlayer => roundPlayer.PlayerId)
                .Distinct()
                .Count() - 2;
            return botCount;
        }

        public Game GetContinueableGame(long userId)
        {
            Game continueableGame = _dbContext.Games
                .Where(game => !game.IsFinished)
                .Join(
                    _dbContext.RoundPlayers.Where(roundPlayer => roundPlayer.PlayerId == userId),
                    game => game.Id,
                    round => round.GameId,
                    (game, round) => game)
                .FirstOrDefault();
            return continueableGame;
        }

        public IEnumerable<Game> GetGamesHistory(long userId)
        {
            IEnumerable<Game> gamesHistory = _dbContext.Games
                .Include(game => game.RoundPlayers)
                .GroupJoin(
                    _dbContext.RoundPlayers.Where(roundPlayer => roundPlayer.PlayerId == userId),
                    game => game.Id,
                    roundPlayer => roundPlayer.GameId,
                    (game, roundPlayers) => game);
            return gamesHistory;
        }

        public long GetGameIdBySkipCount(long userId, int gameSkipCount)
        {
            long gameId = _dbContext.Games
                .GroupJoin(
                    _dbContext.RoundPlayers
                        .Where(roundPlayer => roundPlayer.PlayerId == userId),
                    game => game.Id,
                    roundPlayer => roundPlayer.GameId,
                    (game, roundPlayers) => new { game.Id, game.CreationTime })
                .OrderByDescending(game => game.CreationTime)
                .Skip(gameSkipCount)
                .First()
                .Id;
            return gameId;
        }

        public IEnumerable<RoundPlayerState> GetGameInfo(long userId, int gameSkipCount)
        {
            IEnumerable<RoundPlayerState> roundStates = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.PlayerId == userId && roundPlayer.GameId == _dbContext.RoundPlayers
                    .Where(tmpRoundPlayer => tmpRoundPlayer.PlayerId == userId)
                    .Select(tmpRoundPlayer => tmpRoundPlayer.Game)
                    .Distinct()
                    .OrderByDescending(game => game.CreationTime)
                    .Skip(gameSkipCount)
                    .First()
                    .Id)
                .Select(roundPlayer => roundPlayer.State);
            return roundStates;
        }
    }
}
