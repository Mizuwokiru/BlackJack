using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : AbstractRepository<Round>
    {
        public RoundRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
