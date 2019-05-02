using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>, IRoundPlayerRepository
    {
        public RoundPlayerRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public IEnumerable<RoundPlayer> GetLastRoundInfo(long gameId)
        {
            string sqlQuery =
                @"SELECT * FROM RoundPlayers
                  INNER JOIN Players ON Players.Id = RoundPlayers.PlayerId
                  WHERE GameId = @GameId AND RoundPlayers.CreationTime = (
                      SELECT MAX(CreationTime) FROM RoundPlayers
                      WHERE GameId = @GameId
                  )
                  ORDER BY Players.Name, RoundPlayers.Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundPlayer> lastRoundInfo = connection.Query<RoundPlayer, Player, RoundPlayer>(
                    sqlQuery,
                    (roundPlayer, player) =>
                    {
                        roundPlayer.Player = player;
                        return roundPlayer;
                    },
                    new { GameId = gameId })
                    .Distinct()
                    .ToList();
                return lastRoundInfo;
            }
        }

        public RoundPlayer GetLastRoundPlayerInfo(long gameId, long playerId)
        {
            string sqlQuery =
                @"SELECT * FROM RoundPlayers
                  INNER JOIN Players ON Players.Id = RoundPlayers.PlayerId
                  WHERE GameId = @GameId AND RoundPlayers.CreationTime = (
                      SELECT MAX(CreationTime) FROM RoundPlayers
                      WHERE GameId = @GameId
                  ) AND PlayerId = @PlayerId";
            using (var connection = new SqlConnection(_connectionString))
            {
                RoundPlayer lastRoundPlayerInfo = connection.Query<RoundPlayer, Player, RoundPlayer>(
                    sqlQuery,
                    (roundPlayer, player) =>
                    {
                        roundPlayer.Player = player;
                        return roundPlayer;
                    },
                    new { GameId = gameId, PlayerId = playerId })
                    .First();
                return lastRoundPlayerInfo;
            }
        }

        public IEnumerable<RoundPlayer> GetRoundInfo(long gameId, int roundSkipCount)
        {
            string sqlQuery =
                @"SELECT * FROM RoundPlayers
                  INNER JOIN Players ON Players.Id = RoundPlayers.PlayerId
                  WHERE GameId = @GameId AND RoundPlayers.CreationTime = (
	                  SELECT CreationTime FROM (
		                  SELECT CreationTime, ROW_NUMBER() OVER (ORDER BY CreationTime) AS RoundIndex FROM RoundPlayers
		                  WHERE GameId = @GameId
		                  GROUP BY CreationTime
	                  ) Round
	                  WHERE RoundIndex > @RoundSkip AND RoundIndex <= @RoundSkip + 1
                  )
                  ORDER BY Players.Type, RoundPlayers.Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundPlayer> roundInfo = connection.Query<RoundPlayer, Player, RoundPlayer>(
                    sqlQuery,
                    (roundPlayer, player) =>
                    {
                        roundPlayer.Player = player;
                        return roundPlayer;
                    },
                    new { GameId = gameId, RoundSkip = roundSkipCount })
                    .Distinct()
                    .ToList();
                return roundInfo;
            }
        }
    }
}
