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
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public void FillRoundPlayersCards(IEnumerable<RoundPlayer> roundPlayers)
        {
            string sqlQuery =
                @"SELECT * FROM RoundPlayerCards
                  INNER JOIN Cards ON Cards.Id = RoundPlayerCards.CardId
                  WHERE RoundPlayerId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                foreach (var roundPlayer in roundPlayers)
                {
                    List<RoundPlayerCard> cards = connection.Query<RoundPlayerCard, Card, RoundPlayerCard>(
                        sqlQuery,
                        (roundPlayerCard, card) =>
                        {
                            roundPlayerCard.Card = card;
                            return roundPlayerCard;
                        },
                        roundPlayer)
                        .Distinct()
                        .ToList();
                    roundPlayer.Cards = cards;
                }
            }
        }

        public IEnumerable<Card> GetLastRoundCards(long gameId)
        {
            string sqlQuery =
                @"SELECT Cards.* FROM Cards
                  INNER JOIN RoundPlayerCards ON RoundPlayerCards.CardId = Cards.Id
                  WHERE RoundPlayerId IN (
	                  SELECT Id FROM RoundPlayers
	                  WHERE GameId = @GameId AND CreationTime = (
		                  SELECT MAX(CreationTime) FROM RoundPlayers
		                  WHERE GameId = @GameId
	                  )
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Card> cards =
                    connection.Query<Card>(sqlQuery, new { GameId = gameId });
                return cards;
            }
        }

        public IEnumerable<Card> GetLastRoundPlayerCards(long playerId, long gameId)
        {
            string sqlQuery =
                @"SELECT Cards.* FROM Cards
                  INNER JOIN RoundPlayerCards ON Cards.Id = RoundPlayerCards.CardId
                  WHERE RoundPlayerId = (
                      SELECT TOP 1 Id FROM RoundPlayers
	                  WHERE GameId = @GameId AND PlayerId = @PlayerId
	                  ORDER BY CreationTime DESC
                  )";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Card> cards =
                    connection.Query<Card>(sqlQuery, new { PlayerId = playerId, GameId = gameId });
                return cards;
            }
        }
    }
}
