using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Enums;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<string> GetUsers()
        {
            IEnumerable<string> userNames = _dbContext.Players
                .Where(player => player.Type == PlayerType.User)
                .Select(player => player.Name);
            return userNames;
        }

        public Player GetUser(string name)
        {
            Player user = _dbContext.Players
                .Where(player => player.Name == name && player.Type == PlayerType.User)
                .FirstOrDefault();
            return user;
        }

        public int GetBotCount()
        {
            int botCount = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot)
                .Count();
            return botCount;
        }

        public List<Player> GetBots(int count)
        {
            List<Player> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot)
                .Take(count)
                .ToList();
            return bots;
        }
    }
}
