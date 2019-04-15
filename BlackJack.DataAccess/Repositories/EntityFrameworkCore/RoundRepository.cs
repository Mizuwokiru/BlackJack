using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
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

        private IQueryable<Round> GetLastRounds(long gameId)
        {
            IQueryable<Round> lastRounds = _dbContext.Rounds
                .Where(lastRound => lastRound.GameId == gameId && lastRound.CreationTime ==
                    _dbContext.Rounds
                        .Where(round => round.GameId == gameId)
                        .Max(round => round.CreationTime));
            return lastRounds;
        }

        public IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId)
        {
            IEnumerable<RoundInfoModel> roundInfoModels = GetLastRounds(gameId)
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
                    });
            return roundInfoModels;
        }

        public StepInfoModel GetStepInfo(long userId, long gameId)
        {
            long userRoundId = _dbContext.Rounds
                .Where(round => round.PlayerId == userId && round.GameId == gameId)
                .OrderByDescending(round => round.CreationTime)
                .Select(round => round.Id)
                .FirstOrDefault();
            List<Card> cards = GetLastRounds(gameId)
                .Join(
                    _dbContext.RoundCards,
                    round => round.Id,
                    roundCard => roundCard.RoundId,
                    (round, roundCard) => roundCard.Card)
                .ToList();
            var stepInfoModel = new StepInfoModel
            {
                UserRoundId = userRoundId,
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

        public IEnumerable<IEnumerable<RoundInfoModel>> GetHistoryRoundsInfo(long userId, int skipCount)
        {
            Game choosenGame = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Select(round => round.Game)
                .OrderByDescending(game => game.CreationTime)
                .Distinct()
                .Skip(skipCount)
                .First();

            IEnumerable<IEnumerable<RoundInfoModel>> historyRoundInfos = _dbContext.Rounds
                .Where(round => round.GameId == choosenGame.Id)
                .GroupBy(round => round.CreationTime)
                .Select(rounds => new List<RoundInfoModel>(
                    rounds.Select(round => new RoundInfoModel
                    {
                        PlayerName = round.Player.Name,
                        PlayerType = round.Player.Type,
                        Cards = round.Cards.Select(roundCard => roundCard.Card).ToList(),
                        State = round.State
                    })));
            return historyRoundInfos;
        }
    }
}
