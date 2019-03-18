using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RoundPlayerCard> GetRoundPlayerCards(int roundPlayerId)
        {
            return _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Cards;
        }
    }
}
