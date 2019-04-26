using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId)
        {
            string sqlQuery =
                @"SELECT Rounds.Id AS RoundId, Rounds.State, Players.Name AS PlayerName, Players.Type AS PlayerType FROM Rounds
                  INNER JOIN Players ON Players.Id = Rounds.PlayerId
                  WHERE GameId = @GameId AND Rounds.CreationTime = (
                      SELECT MAX(CreationTime) FROM Rounds
                      WHERE GameId = @GameId
                  )
                  ORDER BY PlayerName, RoundId";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundInfoModel> roundInfoModels = connection.Query<RoundInfoModel>(sqlQuery, new { GameId = gameId });
                return roundInfoModels;
            }
        }

        public StepInfoModel GetStepInfo(long userId, long gameId)
        {
            string sqlQuery =
                @"SELECT TOP 1 * FROM Rounds
                  WHERE PlayerId = @UserId AND GameId = @GameId
                  ORDER BY CreationTime DESC ;
                  SELECT Cards.* FROM Rounds
                  INNER JOIN RoundCards ON RoundCards.RoundId = Rounds.Id
                  INNER JOIN Cards ON Cards.Id = RoundCards.CardId
                  WHERE GameId = @GameId AND Rounds.CreationTime = (
	                  SELECT MAX(CreationTime) FROM Rounds
	                  WHERE GameId = @GameId
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (SqlMapper.GridReader reader = connection.QueryMultiple(sqlQuery, new { UserId = userId, GameId = gameId }))
                {
                    Round userRound = reader.Read<Round>().Single();
                    var stepInfo = new StepInfoModel
                    {
                        UserRoundId = userRound.Id,
                        UserState = userRound.State,
                        RoundsCards = reader.Read<Card>()
                    };
                    return stepInfo;
                }
            }
        }

        public void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            string sqlQuery =
                @"UPDATE Rounds SET State = @State WHERE Id = @RoundId";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, roundInfoModels);
            }
        }

        public IEnumerable<RoundState> GetRoundStates(long userId, int gameSkipCount)
        {
            string sqlQuery =
                @"SELECT State FROM Rounds
                  WHERE PlayerId = @UserId AND GameId = (
                      SELECT GameId FROM (
                          SELECT GameId, ROW_NUMBER() OVER (ORDER BY Games.CreationTime DESC) AS GameIndex
                          FROM (
                              SELECT DISTINCT GameId FROM Rounds
                              WHERE PlayerId = @UserId
                          ) RoundGames
                          INNER JOIN Games ON Games.Id = GameId
                      ) GamesByPlayer
                      WHERE GameIndex > @Skip AND GameIndex <= @Skip + 1
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundState> roundStates = connection.Query<RoundState>(sqlQuery, new { UserId = userId, Skip = gameSkipCount });
                return roundStates;
            }
        }

        public IEnumerable<RoundInfoModel> GetRoundInfo(long userId, long gameId, int roundSkipCount)
        {
            string sqlQuery =
                @"SELECT Rounds.Id AS RoundId, Rounds.State, Players.Name AS PlayerName, Players.Type AS PlayerType FROM Rounds
                  INNER JOIN Players ON Players.Id = Rounds.PlayerId
                  WHERE GameId = @GameId AND Rounds.CreationTime = (
	                  SELECT CreationTime FROM (
		                  SELECT CreationTime, ROW_NUMBER() OVER (ORDER BY CreationTime) AS RoundIndex FROM Rounds
		                  WHERE GameId = @GameId
		                  GROUP BY CreationTime
	                  ) Round
	                  WHERE RoundIndex > @RoundSkip AND RoundIndex <= @RoundSkip + 1
                  )
                  ORDER BY Players.Type, Rounds.Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<RoundInfoModel> roundInfoModels = connection.Query<RoundInfoModel>(sqlQuery,
                    new { UserId = userId, GameId = gameId, RoundSkip = roundSkipCount });
                return roundInfoModels;
            }
        }
    }
}
