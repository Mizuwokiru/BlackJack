using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Game> GetUserGames(int userId) =>
            _dbContext.Set<Game>().Where(game => game.User.Id == userId);
    }
}
