using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundGamePlayerCardRepository : AbstractRepository<RoundGamePlayerCard>
    {
        public RoundGamePlayerCardRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
