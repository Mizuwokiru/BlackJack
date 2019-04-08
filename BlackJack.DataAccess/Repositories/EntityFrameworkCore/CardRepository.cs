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

        public List<Card> GetCards(long roundId)
        {
            List<Card> cards = _dbContext.RoundCards
                .Where(roundCard => roundCard.RoundId == roundId)
                .Select(roundCard => roundCard.Card)
                .ToList();
            return cards;
        }
    }
}
