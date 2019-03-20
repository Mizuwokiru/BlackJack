using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Player> GetBots()
        {
            return _dbContext.Set<Player>().Where(player => player.IsBot);
        }

        public IEnumerable<Player> GetPlayables()
        {
            return _dbContext.Set<Player>().Where(player => !player.IsBot);
        }

        public Player GetPlayerOfGamePlayer(int gamePlayerId)
        {
            return _dbContext.Set<GamePlayer>().Find(gamePlayerId).Player;
        }

        public Player GetPlayerOfRoundPlayer(int roundPlayerId)
        {
            return _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Player;
        }
    }
}
