using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GamePlayerRepository : AbstractRepository<GamePlayer>
    {
        public GamePlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
