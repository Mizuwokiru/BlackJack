using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
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

        public int GetBotCount()
        {
            int botCount = _dbContext.Players.Count();
            return botCount;
        }

        public List<Player> GetBots(int botCount)
        {
            List<Player> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot)
                .Take(botCount)
                .ToList();
            return bots;
        }

        public Player GetDealer()
        {
            Player dealer = Get(BlackJackConstants.DealerId);
            return dealer;
        }

        public Player GetPlayer(long roundId)
        {
            Player player = _dbContext.Rounds
                .Find(roundId)
                .Player;
            return player;
        }

        public Player GetUser(string userName)
        {
            Player user = _dbContext.Players
                .FirstOrDefault(player => player.Name.Equals(userName, System.StringComparison.CurrentCultureIgnoreCase));
            return user;
        }

        public List<string> GetUserNames()
        {
            List<string> userNames = _dbContext.Players
                .Where(player => player.Type == PlayerType.User)
                .Select(player => player.Name)
                .ToList();
            return userNames;
        }
    }
}
