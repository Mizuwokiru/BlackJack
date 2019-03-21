using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Card GetCardOfRoundPlayerCard(int roundPlayerCard) =>
            _dbContext.Set<RoundPlayerCard>().Find(roundPlayerCard).Card;
    }
}
