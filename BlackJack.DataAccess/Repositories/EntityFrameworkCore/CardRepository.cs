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

        public IEnumerable<Card> GetCards(IEnumerable<RoundCard> roundCards)
        {
            IEnumerable<Card> cards = roundCards
                .Select(roundCard => roundCard.Card);
            return cards;
        }
    }
}
