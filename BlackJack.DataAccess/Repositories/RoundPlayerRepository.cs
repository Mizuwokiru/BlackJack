using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundPlayerRepository : AbstractRepository<RoundPlayer>
    {
        public RoundPlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
