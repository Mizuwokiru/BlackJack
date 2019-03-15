using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>
    {
        public RoundPlayerCardRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
