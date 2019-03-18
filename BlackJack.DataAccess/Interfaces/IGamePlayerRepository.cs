using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGamePlayerRepository
    {
        IEnumerable<GamePlayer> GetGamePlayers(int gameId);
    }
}
