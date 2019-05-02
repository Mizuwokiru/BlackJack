using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public int GetBotCount(long gameId)
        {
            string sqlQuery =
                @"SELECT COUNT(*) FROM RoundPlayers
                  WHERE GameId = @GameId AND CreationTime = (
	                  SELECT TOP 1 CreationTime FROM RoundPlayers
	                  WHERE GameId = @GameId
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                int botCount = connection.QuerySingle<int>(sqlQuery, new { GameId = gameId }) - 2;
                return botCount;
            }
        }

        public Game GetContinueableGame(long userId)
        {
            string sqlQuery =
                @"SELECT DISTINCT Games.* FROM Games
                  INNER JOIN RoundPlayers ON RoundPlayers.GameId = Games.Id
                  WHERE PlayerId = @UserId AND IsFinished = 0";
            using (var connection = new SqlConnection(_connectionString))
            {
                Game game = connection.QueryFirstOrDefault<Game>(sqlQuery, new { UserId = userId });
                return game;
            }
        }

        public long GetGameIdBySkipCount(long userId, int gameSkipCount)
        {
            string sqlQuery =
                @"SELECT GameId FROM (
			          SELECT GameId, ROW_NUMBER() OVER (ORDER BY CreationTime DESC) AS GameIndex
			          FROM (
				          SELECT DISTINCT RoundPlayers.GameId, Games.CreationTime FROM Games
				          INNER JOIN RoundPlayers ON RoundPlayers.GameId = Games.Id
				          WHERE RoundPlayers.PlayerId = @UserId
			          ) RP
		          ) GamesByPlayer
		          WHERE GameIndex > @GameSkip AND GameIndex <= @GameSkip + 1";
            using (var connection = new SqlConnection(_connectionString))
            {
                long gameId = connection.QueryFirst<long>(sqlQuery, new { UserId = userId, GameSkip = gameSkipCount });
                return gameId;
            }
        }

        public IEnumerable<RoundPlayerState> GetGameInfo(long userId, int gameSkipCount)
            {
            string sqlQuery =
                @"SELECT State FROM RoundPlayers
                  WHERE PlayerId = @UserId AND GameId = (
                      SELECT GameId FROM (
                          SELECT GameId, ROW_NUMBER() OVER (ORDER BY Games.CreationTime DESC) AS GameIndex
                          FROM (
                              SELECT DISTINCT GameId FROM RoundPlayers
                              WHERE PlayerId = @UserId
                          ) RoundGames
                          INNER JOIN Games ON Games.Id = GameId
                      ) GamesByPlayer
                      WHERE GameIndex > @Skip AND GameIndex <= @Skip + 1
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundPlayerState> roundStates = connection.Query<RoundPlayerState>(sqlQuery, new { UserId = userId, Skip = gameSkipCount });
                return roundStates;
            }
        }

        public IEnumerable<Game> GetGamesHistory(long userId)
        {
            string sqlQuery =
                @"SELECT * FROM Games
                  INNER JOIN RoundPlayers ON RoundPlayers.GameId = Games.Id
                  WHERE PlayerId = @UserId";
            using (var connection = new SqlConnection(_connectionString))
            {
                var gamesDictionary = new Dictionary<long, Game>();

                IEnumerable<Game> games = connection.Query<Game, RoundPlayer, Game>(
                    sqlQuery,
                    (game, roundPlayer) =>
                    {
                        Game gameEntry;
                        if (!gamesDictionary.TryGetValue(game.Id, out gameEntry))
                        {
                            gameEntry = game;
                            gameEntry.RoundPlayers = new List<RoundPlayer>();
                            gamesDictionary.Add(gameEntry.Id, gameEntry);
                        }

                        gameEntry.RoundPlayers.Add(roundPlayer);
                        return gameEntry;
                    },
                    new { UserId = userId })
                    .Distinct()
                    .ToList();
                return games;
            }
        }
    }
}
