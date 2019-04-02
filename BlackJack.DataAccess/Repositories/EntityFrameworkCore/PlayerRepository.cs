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
        public PlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Player> GetBots(int botCount)
        {
            IEnumerable<Player> bots = _dbContext.Players
                .Where(player => player.Type == PlayerType.Bot)
                .Take(botCount);
            return bots;
        }

        public Player GetDealer()
        {
            Player dealer = Get(1);
            return dealer;
        }

        public Player GetPlayer(string name)
        {
            Player player = _dbContext.Players
                .Where(tmpPlayer => tmpPlayer.Name == name)
                .FirstOrDefault();
            return player;
        }

        public Player GetPlayer(long roundId)
        {
            Player player = _dbContext.Rounds
                .Find(roundId).Player;
            return player;
        }

        public IEnumerable<string> GetPlayerNames()
        {
            IEnumerable<string> playerNames = _dbContext.Players
                .Where(player => player.Type == PlayerType.User)
                .Select(player => player.Name);
            return playerNames;
        }

        public IEnumerable<Player> GetPlayersForGame(long gameId)
        {
            IEnumerable<Player> players = _dbContext.Rounds
                .Where(round => round.GameId == gameId)
                .Select(round => round.Player);
            return players;
        }
    }
}
