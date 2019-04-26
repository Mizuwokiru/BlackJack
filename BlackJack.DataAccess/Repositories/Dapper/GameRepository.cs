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
                @"SELECT DISTINCT Games.* FROM Games
                  INNER JOIN Rounds ON Rounds.GameId = Games.Id
                  WHERE PlayerId = @UserId AND IsFinished = 0";
            using (var connection = new SqlConnection(_connectionString))
            {
                Game game = connection.QueryFirstOrDefault<Game>(sqlQuery, new { UserId = userId });
                return game;
            }
        }

        public int GetPlayerCount(long gameId)
        {
            string sqlQuery =
                @"SELECT COUNT(*) FROM Rounds
                  WHERE GameId = @GameId AND CreationTime = (
	                  SELECT TOP 1 CreationTime FROM Rounds
	                  WHERE GameId = @GameId
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
                @"SELECT CreationTime, RoundCount, PlayerCount
                  FROM (
	                  SELECT DISTINCT Games.* FROM Games
	                  INNER JOIN Rounds ON Rounds.GameId = Games.Id
	                  WHERE Rounds.PlayerId = @UserId
                  ) AS GamesByPlayer
                  INNER JOIN (
	                  SELECT DISTINCT GameId, COUNT(*) AS RoundCount FROM Rounds
	                  GROUP BY GameId, PlayerId
                  ) AS RC ON RC.GameId = GamesByPlayer.Id
                  INNER JOIN (
	                  SELECT DISTINCT GameId, COUNT(*) AS PlayerCount FROM Rounds
	                  GROUP BY GameId, CreationTime
                  ) AS PC ON PC.GameId = GamesByPlayer.Id
                  ORDER BY CreationTime DESC";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<GamesHistoryInfoModel> gamesHistory = connection.Query<GamesHistoryInfoModel>(sqlQuery, new { UserId = userId });
                return gamesHistory;
            }
        }

        public long GetGameIdBySkipCount(long userId, int gameSkipCount)
        {
            string sqlQuery =
                @"SELECT GameId FROM (
			          SELECT GameId, ROW_NUMBER() OVER (ORDER BY CreationTime DESC) AS GameIndex
			          FROM (
				          SELECT DISTINCT Rounds.GameId, Games.CreationTime FROM Games
				          INNER JOIN Rounds ON Rounds.GameId = Games.Id
				          WHERE Rounds.PlayerId = @UserId
			          ) PlayerRounds
		          ) GamesByPlayer
		          WHERE GameIndex > @GameSkip AND GameIndex <= @GameSkip + 1";
            using (var connection = new SqlConnection(_connectionString))
            {
                long gameId = connection.QueryFirst<long>(sqlQuery, new { UserId = userId, GameSkip = gameSkipCount });
                return gameId;
            }
        }
    }
}
