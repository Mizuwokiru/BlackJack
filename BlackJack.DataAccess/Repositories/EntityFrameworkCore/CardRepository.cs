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
            IEnumerable<Card> cards = _dbContext.RoundCards
                .Where(roundCard => roundCard.Round.CreationTime ==
                    _dbContext.Rounds
                        .Where(round => round.GameId == gameId && round.PlayerId == playerId)
                        .Max(round => round.CreationTime)
                    && roundCard.Round.GameId == gameId && roundCard.Round.PlayerId == playerId)
                .Select(roundCard => roundCard.Card);
            return cards;
        }
    }
}
