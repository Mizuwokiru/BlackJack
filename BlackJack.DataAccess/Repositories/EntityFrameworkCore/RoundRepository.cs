using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        private IQueryable<Round> GetLastRounds(long gameId)
        {
            DateTime? lastRoundTime = _dbContext.Rounds
                .Where(round => round.GameId == gameId)
                .Select(round => round.CreationTime)
                .Max();
            IQueryable<Round> lastRounds = _dbContext.Rounds
                .Where(round => round.GameId == gameId && round.CreationTime == lastRoundTime);
            return lastRounds;
        }

        public IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId)
        {
            DateTime? lastRoundTime = _dbContext.Rounds
                .Where(round => round.GameId == gameId)
                .Select(round => round.CreationTime)
                .Max();
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
                        Cards = round.Cards.Select(roundCard => roundCard.Card).ToList(),
                        RoundState = round.State
                    });
            return roundInfoModels;
        }

        public StepInfoModel GetStepInfo(long userId, long gameId)
        {
            Round userRound = _dbContext.Rounds
                .Where(round => round.PlayerId == userId && round.GameId == gameId)
                .OrderByDescending(round => round.CreationTime)
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
                UserRoundId = userRound.Id,
                RoundsCards = cards
            };
            return stepInfoModel;
        }

        public void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            var sqlStringBuilder = new StringBuilder();
            foreach (var roundInfo in roundInfoModels)
            {
                sqlStringBuilder.AppendLine($"UPDATE {nameof(_dbContext.Rounds)} SET State = {(int)roundInfo.RoundState} WHERE Id = {roundInfo.RoundId};");
            }
            _dbContext.Database.ExecuteSqlCommand(sqlStringBuilder.ToString());
        }
    }
}
