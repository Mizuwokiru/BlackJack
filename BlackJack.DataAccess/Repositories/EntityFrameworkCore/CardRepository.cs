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

        public List<Card> GetCards(IEnumerable<Round> rounds)
        {
            List<Card> cards = _dbContext.RoundCards
                .Where(roundCard => rounds.Contains(roundCard.Round))
                .Select(roundCard => roundCard.Card)
                .ToList();
            return cards;
        }

        public List<Card> GetCards(long roundId)
        {
            List<Card> cards = _dbContext.Rounds
                .Find(roundId).Cards
                .Select(roundCard => roundCard.Card)
                .ToList();
            return cards;
        }
    }
}
