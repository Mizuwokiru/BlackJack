using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Player> GetBots()
        {
            return _dbContext.Players.Where(player => player.IsBot);
        }

        public Player GetPlayerByName(string playerName)
        {
            return _dbContext.Players
                .Where(player => player.Name == playerName)
                .FirstOrDefault();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _dbContext.Players.Where(player => !player.IsBot);
        }

        public IEnumerable<Player> GetOrCreateBots(int botCount)
        {
            List<Player> bots = GetBots().ToList();
            if (bots.Count < botCount)
            {
                for (int i = bots.Count; i < botCount; i++)
                {
                    var bot = new Player { Name = $"Bot #{i + 1}", IsBot = true };
                    Add(bot);
                    bots.Add(bot);
                }
                return bots;
            }
            return bots.GetRange(0, botCount);
        }
    }
}
