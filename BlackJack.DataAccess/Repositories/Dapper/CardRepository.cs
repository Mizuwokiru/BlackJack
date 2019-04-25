using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public IEnumerable<Card> GetPlayerCards(long playerId, long gameId)
        {
            string sqlQuery =
                @"SELECT [Cards].* FROM [Cards]
                  INNER JOIN [RoundCards] ON [Cards].[Id] = [RoundCards].[CardId]
                  WHERE [RoundCards].[RoundId] = (
                      SELECT TOP 1 [Id] FROM [Rounds]
	                  WHERE [CreationTime] = (
                          SELECT MAX([CreationTime])
		                  FROM [Rounds]
		                  WHERE [GameId] = @GameId AND [PlayerId] = @PlayerId
                      )
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Card> cards =
                    connection.Query<Card>(sqlQuery, new { GameId = gameId, PlayerId = playerId });
                return cards;
            }
        }

        public void GetRoundCards(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            string sqlQuery =
                @"SELECT [Cards].* FROM [RoundCards]
                  INNER JOIN [Cards] ON [Cards].[Id] = [RoundCards].[CardId]
                  WHERE [RoundCards].[RoundId] = @RoundId";
            using (var connection = new SqlConnection(_connectionString))
            {
                foreach (var roundInfoModel in roundInfoModels)
                {
                    List<Card> cards = connection.Query<Card>(sqlQuery, roundInfoModel).ToList();
                    roundInfoModel.Cards = cards;
                }
            }
        }
    }
}
