using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public int GetBotCount()
        {
            int botCount = _dbContext.Players
                .Count(player => player.Type == PlayerType.Bot);
            return botCount;
        }

        public IEnumerable<Player> GetBots(int neededCount)
        {
            IEnumerable<Player> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot);
            return bots;
        }

        public IEnumerable<string> GetUserNames()
        {
            IEnumerable<string> userNames = _dbContext.Players
                .Where(player => player.Type == PlayerType.User)
                .Select(player => player.Name);
            return userNames;
        }
    }
}
