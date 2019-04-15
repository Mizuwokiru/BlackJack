using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Card> GetPlayerCards(long playerId, long gameId)
        {
            IEnumerable<Card> cards = _dbContext.Rounds
                .Where(round => round.PlayerId == playerId && round.GameId == gameId)
                .OrderByDescending(round => round.CreationTime)
                .First()
                .Cards
                .Select(roundCard => roundCard.Card);
            return cards;
        }
    }
}
