using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Card GetCardOfRoundPlayerCard(int roundPlayerCard)
        {
            return _dbContext.Set<RoundPlayerCard>().Find(roundPlayerCard).Card;
        }
    }
}
