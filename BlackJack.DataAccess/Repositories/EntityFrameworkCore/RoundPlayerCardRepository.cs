using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(GameDbContext dbContext) : base(dbContext)
        {
        }
    }
}
