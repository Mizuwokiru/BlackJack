using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetUserGames(int userId);
    }
}
