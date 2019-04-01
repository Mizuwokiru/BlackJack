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
            return _dbContext.Players.Where(player => !player.IsPlayable);
        }

        public Player GetPlayerByName(string playerName)
        {
            return _dbContext.Players
                .Where(player => player.Name == playerName)
                .FirstOrDefault();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _dbContext.Players.Where(player => player.IsPlayable);
        }

        public IEnumerable<Player> GetOrCreateBots(int botCount)
        {
            List<Player> bots = GetBots().ToList();
            if (bots.Count < botCount)
            {
                for (int i = bots.Count; i < botCount; i++)
                {
                    var bot = new Player { Name = $"Bot #{i + 1}" };
                    Add(bot);
                    bots.Add(bot);
                }
                return bots;
            }
            return bots.GetRange(0, botCount);
        }

        public Player GetOrCreatePlayer(string name)
        {
            Player player = GetPlayerByName(name);
            if (player == null)
            {
                player = new Player { Name = name, IsPlayable = true };
                Add(player);
            }
            return player;
        }

        public IEnumerable<Player> GetPlayersByGame(int gameId)
        {
            return _dbContext.Rounds
                .Sele
        }
    }
}
