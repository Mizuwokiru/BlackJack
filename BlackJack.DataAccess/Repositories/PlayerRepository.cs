using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
