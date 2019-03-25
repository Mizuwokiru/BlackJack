using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundPlayerCard> GetRoundPlayerCardsByPlayer(int roundPlayerId) =>
            _dbContext.Set<RoundPlayerCard>().Where(roundPlayerCard => roundPlayerCard.RoundPlayer.Id == roundPlayerId);
    }
}
