using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Enums;
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

        public IEnumerable<RoundInfoModel> GetLastRoundInfo(long gameId)
        {
            IEnumerable<RoundInfoModel> roundInfoModels = GetLastRounds(gameId).Join(
                _dbContext.Players,
                round => round.PlayerId,
                player => player.Id,
                (round, player) => new RoundInfoModel
                {
                    RoundId = round.Id,
                    Player = new PlayerModel { Name = player.Name, Type = player.Type },
                    Cards = round.Cards
                                .Select(roundCard => roundCard.Card)
                                .Select(card => new CardModel { Id = card.Id, Suit = card.Suit, Rank = card.Rank })
                                .ToList(),
                    State = round.State
                });
            return roundInfoModels;
        }

        public void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            var sqlStringBuilder = new StringBuilder();
            foreach (var roundInfo in roundInfoModels)
            {
                sqlStringBuilder.Append($"UPDATE {nameof(_dbContext.Rounds)} SET State = {(int)roundInfo.State} WHERE Id = {roundInfo.RoundId};{Environment.NewLine}");
            }
            _dbContext.Database.ExecuteSqlCommand(sqlStringBuilder.ToString());
        }
    }
}
