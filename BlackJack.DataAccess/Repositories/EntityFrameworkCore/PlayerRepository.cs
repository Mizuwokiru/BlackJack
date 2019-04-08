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

        public IEnumerable<Player> GetBots()
        {
            IEnumerable<Player> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot);
            return bots;
        }

        public Player GetDealer()
        {
            Player dealer = Get(BlackJackConstants.DealerId);
            return dealer;
        }

        public Player GetUser(string userName)
        {
            Player user = _dbContext.Players
                .FirstOrDefault(player => player.Name.Equals(userName, System.StringComparison.CurrentCultureIgnoreCase));
            return user;
        }
    }
}
