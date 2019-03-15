using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGamePlayerRepository
    {
        public GameRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
