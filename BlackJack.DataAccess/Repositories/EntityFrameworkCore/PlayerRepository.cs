using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Player>> GetBots(int botCount)
        {
            Task<List<Player>> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot)
                .Take(botCount)
                .ToListAsync();
            return await bots;
        }

        public async Task<Player> GetDealer()
        {
            Task<Player> dealer = Get(BlackJackConstants.DealerId);
            return await dealer;
        }

        public async Task<Player> GetPlayer(string playerName)
        {
            Task<Player> player = _dbContext.Players
                .FirstOrDefaultAsync(tmpPlayer => tmpPlayer.Name.Equals(playerName, System.StringComparison.CurrentCultureIgnoreCase));
            return await player;
        }

        public async Task<Player> GetPlayer(long roundId)
        {
            Round round = await _dbContext.Rounds
                .FindAsync(roundId);
            return round.Player;
        }

        public async Task<IEnumerable<string>> GetUserNames()
        {
            Task<List<string>> userNames = _dbContext.Players
                .Where(player => player.Type == PlayerType.User)
                .Select(user => user.Name)
                .ToListAsync();
            return await userNames;
        }
    }
}
