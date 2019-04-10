using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public List<Card> GetCardsByGame(long gameId)
        {
            IEnumerable<Round> rounds = _dbContext.Games
                .Find(gameId).Rounds;
            List<Card> cards = rounds
                .Where(round => round.CreationTime == rounds.Select(r => r.CreationTime).Max())
                .Join(
                    _dbContext.RoundCards,
                    round => round.Id,
                    roundCard => roundCard.RoundId,
                    (round, roundCard) => roundCard.Card)
                .ToList();
            return cards;
        }

        public List<Card> GetCardByRound(long roundId)
        {
            List<Card> cards = _dbContext.Rounds
                .Find(roundId).Cards
                .Select(roundCard => roundCard.Card)
                .ToList();
            return cards;
        }
    }
}
