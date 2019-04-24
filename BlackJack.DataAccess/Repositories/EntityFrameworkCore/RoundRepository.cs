using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId)
        {
            IEnumerable<RoundInfoModel> roundInfoModels = _dbContext.Rounds
                .Where(lastRound => lastRound.GameId == gameId && lastRound.CreationTime ==
                    _dbContext.Rounds
                        .Where(round => round.GameId == gameId)
                        .Max(round => round.CreationTime))
                .Join(
                    _dbContext.Players,
                    round => round.PlayerId,
                    player => player.Id,
                    (round, player) => new RoundInfoModel
                    {
                        RoundId = round.Id,
                        PlayerName = player.Name,
                        PlayerType = player.Type,
                        Cards = round.Cards.OrderBy(roundCard => roundCard.CreationTime).Select(roundCard => roundCard.Card).ToList(),
                        State = round.State
                    })
                .OrderBy(roundInfoModel => roundInfoModel.PlayerType)
                .ThenBy(roundInfoModel => roundInfoModel.RoundId);
            return roundInfoModels;
        }

        public StepInfoModel GetStepInfo(long userId, long gameId)
        {
            Round userRound = _dbContext.Rounds
                .Where(round => round.PlayerId == userId && round.GameId == gameId)
                .OrderByDescending(round => round.CreationTime)
                .FirstOrDefault();
            IEnumerable<Card> cards = _dbContext.Rounds
                .Where(lastRound => lastRound.GameId == gameId && lastRound.CreationTime ==
                    _dbContext.Rounds
                        .Where(round => round.GameId == gameId)
                        .Max(round => round.CreationTime))
                .Join(
                    _dbContext.RoundCards,
                    round => round.Id,
                    roundCard => roundCard.RoundId,
                    (round, roundCard) => roundCard.Card);
            var stepInfoModel = new StepInfoModel
            {
                UserRoundId = userRound.Id,
                UserState = userRound.State,
                RoundsCards = cards
            };
            return stepInfoModel;
        }

        public void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            var sqlStringBuilder = new StringBuilder();
            foreach (var roundInfo in roundInfoModels)
            {
                sqlStringBuilder.AppendLine($"UPDATE {nameof(_dbContext.Rounds)} SET State = {(int)roundInfo.State} WHERE Id = {roundInfo.RoundId};");
            }
            _dbContext.Database.ExecuteSqlCommand(sqlStringBuilder.ToString());
        }

        public IEnumerable<RoundState> GetRoundStates(long userId, int gameSkipCount)
        {
            IEnumerable<RoundState> roundStates = _dbContext.Rounds
                .Where(round => round.PlayerId == userId && round.GameId == _dbContext.Rounds
                    .Where(tmpRound => tmpRound.PlayerId == userId)
                    .Select(tmpRound => tmpRound.Game)
                    .Distinct()
                    .OrderByDescending(game => game.CreationTime)
                    .Skip(gameSkipCount)
                    .First()
                    .Id)
                .Select(round => round.State);
            return roundStates;
        }

        public IEnumerable<RoundInfoModel> GetRoundInfo(long userId, int gameSkipCount, int roundSkipCount)
        {
            IEnumerable<RoundInfoModel> roundInfos = _dbContext.Rounds
                .Where(round => round.GameId == _dbContext.Rounds
                    .Where(tmpRound => tmpRound.PlayerId == userId)
                    .Select(tmpRound => tmpRound.Game)
                    .Distinct()
                    .OrderByDescending(game => game.CreationTime)
                    .Skip(gameSkipCount)
                    .First()
                    .Id)
                .GroupBy(round => round.CreationTime)
                .Skip(roundSkipCount)
                .First()
                .Join(
                    _dbContext.Players,
                    round => round.PlayerId,
                    player => player.Id,
                    (round, player) => new RoundInfoModel
                    {
                        RoundId = round.Id,
                        PlayerName = player.Name,
                        PlayerType = player.Type,
                        Cards = round.Cards.OrderBy(roundCard => roundCard.CreationTime).Select(roundCard => roundCard.Card).ToList(),
                        State = round.State
                    })
                .OrderBy(roundInfoModel => roundInfoModel.PlayerType)
                .ThenBy(roundInfoModel => roundInfoModel.RoundId);
            return roundInfos;
        }
    }
}
