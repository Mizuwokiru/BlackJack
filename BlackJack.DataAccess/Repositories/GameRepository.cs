using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : AbstractRepository<Game>
    {
        public GameRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
