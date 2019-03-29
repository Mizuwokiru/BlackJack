using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundPlayerCard> GetRoundPlayerCards(int roundPlayerId)
        {
            return _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Cards;
        }
    }
}
