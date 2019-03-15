using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GamePlayerRepository : BaseRepository<GamePlayer>
    {
        public GamePlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
