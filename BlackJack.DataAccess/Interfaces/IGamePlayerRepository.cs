using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGamePlayerRepository : IRepository<GamePlayer>
    {
        IEnumerable<GamePlayer> GetGamePlayers(int gameId);
    }
}
