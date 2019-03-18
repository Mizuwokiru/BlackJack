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
