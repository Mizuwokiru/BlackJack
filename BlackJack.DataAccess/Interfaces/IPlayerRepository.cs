using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerOfGamePlayer(int gamePlayerId);

        Player GetPlayerOfRoundPlayer(int roundPlayerId);

        IEnumerable<Player> GetPlayables();

        IEnumerable<Player> GetBots();


    }
}
