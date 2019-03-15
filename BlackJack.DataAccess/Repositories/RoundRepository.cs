using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>
    {
        public RoundRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
