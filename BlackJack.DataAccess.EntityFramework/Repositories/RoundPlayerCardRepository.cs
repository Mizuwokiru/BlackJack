using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RoundPlayerCard> GetRoundPlayerCards(int roundPlayerId) =>
            _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Cards;
    }
}
