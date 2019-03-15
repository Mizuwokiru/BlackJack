using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>
    {
        public RoundPlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
