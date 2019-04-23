using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public Game GetUnfinishedGame(long userId)
        {
            string sqlQuery =
                @"SELECT [Games].* FROM [Games]
                  INNER JOIN [Rounds] ON [Rounds].[GameId] = [Games].[Id]
                  WHERE [Rounds].[PlayerId] = @UserId AND [Games].[IsFinished] = 0";
            using (var connection = new SqlConnection(_connectionString))
            {
                Game game = connection.QueryFirstOrDefault<Game>(sqlQuery, new { UserId = userId });
                return game;
            }
        }

        public int GetPlayerCount(long gameId)
        {
            string sqlQuery =
                @"SELECT COUNT(*) FROM [Rounds]
                  WHERE [CreationTime] = (
	                  SELECT TOP 1 [CreationTime] FROM [Rounds]
	                  WHERE [GameId] = @GameId
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                int playerCount = connection.QuerySingle<int>(sqlQuery, new { GameId = gameId });
                return playerCount;
            }
        }

        public IEnumerable<GamesHistoryInfoModel> GetGamesHistory(long userId)
        {
            string sqlQuery =
                @"SELECT [GamesByPlayer].[CreationTime], [RoundCounts].[Count] AS [RoundCount], [PlayerCounts].[Count] AS [PlayerCount]
                  FROM (
                   SELECT DISTINCT [Games].* FROM [Games]
                   INNER JOIN [Rounds] ON [Rounds].[GameId] = [Games].[Id]
                   WHERE [Rounds].[PlayerId] = @UserId
                  ) AS [GamesByPlayer]
                  INNER JOIN (
                   SELECT DISTINCT [Rounds].[GameId] AS [GameId], COUNT(*) AS [Count] FROM [Rounds]
                   GROUP BY [Rounds].[GameId], [Rounds].[PlayerId]
                  ) AS [RoundCounts] ON [RoundCounts].[GameId] = [GamesByPlayer].[Id]
                  INNER JOIN (
                   SELECT DISTINCT [Rounds].[GameId] AS [GameId], COUNT(*) AS [Count] FROM [Rounds]
                   GROUP BY [Rounds].[GameId], [Rounds].[CreationTime]
                  ) AS [PlayerCounts] ON [PlayerCounts].[GameId] = [GamesByPlayer].[Id]
                  ORDER BY [GamesByPlayer].[CreationTime] DESC";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<GamesHistoryInfoModel> gamesHistory = connection.Query<GamesHistoryInfoModel>(sqlQuery, new { UserId = userId });
                return gamesHistory;
            }
        }
    }
}
