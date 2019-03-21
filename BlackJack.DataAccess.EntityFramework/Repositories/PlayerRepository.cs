using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Player> GetPlayers() => _dbContext.Set<Player>().Where(player => !player.IsBot);

        public Player GetPlayerOfGamePlayer(int gamePlayerId) => _dbContext.Set<GamePlayer>().Find(gamePlayerId).Player;

        public Player GetPlayerOfRoundPlayer(int roundPlayerId) => _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Player;

        public Player GetOrCreatePlayer(string name)
        {
            Player player = _dbContext.Set<Player>().Where(p => p.Name == name).FirstOrDefault();
            if (player == null)
            {
                player = new Player { Name = name };
                Create(player);
            }
            return player;
        }

        public IEnumerable<Player> GetOrCreateBots(int botCount)
        {
            List<Player> bots = _dbContext.Set<Player>().Where(p => p.IsBot).ToList();
            if (bots.Count < botCount)
            {
                for (int i = bots.Count; i < botCount; i++)
                {
                    var bot = new Player { Name = $"Bot #{i + 1}", IsBot = true };
                    Create(bot);
                    bots.Add(bot);
                }
            }
            return bots;
        }
    }
}
