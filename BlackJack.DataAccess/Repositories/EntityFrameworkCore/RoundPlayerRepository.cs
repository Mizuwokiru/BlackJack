using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>, IRoundPlayerRepository
    {
        public RoundPlayerRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RoundPlayer> GetLastRoundInfo(long gameId)
        {
            IEnumerable<RoundPlayer> roundPlayers = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.GameId == gameId && roundPlayer.CreationTime ==
                    _dbContext.RoundPlayers
                        .Where(tmpRoundPlayer => tmpRoundPlayer.GameId == gameId)
                        .Max(tmpRoundPlayer => tmpRoundPlayer.CreationTime))
                .Include(roundPlayer => roundPlayer.Player)
                .Include(roundPlayer => roundPlayer.Cards)
                .ThenInclude(roundPlayerCard => roundPlayerCard.Card)
                .OrderBy(roundPlayer => roundPlayer.Player.Type)
                .ThenBy(roundPlayer => roundPlayer.Id);
            return roundPlayers;
        }

        public RoundPlayer GetLastRoundPlayerInfo(long gameId, long playerId)
        {
            RoundPlayer roundPlayerInfo = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.GameId == gameId && roundPlayer.PlayerId == playerId && roundPlayer.CreationTime ==
                    _dbContext.RoundPlayers
                        .Where(tmpRoundPlayer => tmpRoundPlayer.GameId == gameId)
                        .Max(tmpRoundPlayer => tmpRoundPlayer.CreationTime))
                .Include(roundPlayer => roundPlayer.Player)
                .Include(roundPlayer => roundPlayer.Cards)
                .ThenInclude(roundPlayerCard => roundPlayerCard.Card)
                .First();
            return roundPlayerInfo;
        }

        public IEnumerable<RoundPlayer> GetRoundInfo(long gameId, int roundSkipCount)
        {
            IEnumerable<RoundPlayer> roundInfo = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.GameId == gameId)
                .Include(roundPlayer => roundPlayer.Player)
                .OrderBy(roundPlayer => roundPlayer.Player.Type)
                .ThenBy(roundPlayer => roundPlayer.Id)
                .GroupBy(roundPlayer => roundPlayer.CreationTime)
                .Skip(roundSkipCount)
                .First();
            return roundInfo;
        }
    }
}
