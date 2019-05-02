using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public void FillRoundPlayersCards(IEnumerable<RoundPlayer> roundPlayers)
        {
            List<IGrouping<long, RoundPlayerCard>> cardsByRoundPlayers = _dbContext.RoundPlayerCards
                .Where(roundPlayerCard => roundPlayers.Any(roundPlayer => roundPlayer.Id == roundPlayerCard.RoundPlayerId))
                .Include(roundPlayerCard => roundPlayerCard.Card)
                .GroupBy(roundPlayerCard => roundPlayerCard.RoundPlayerId)
                .ToList();
            roundPlayers.AsParallel()
                .ForAll(roundPlayer =>
                    roundPlayer.Cards = cardsByRoundPlayers.First(roundPlayerCards => roundPlayerCards.Key == roundPlayer.Id).ToList());
                    
        }

        public IEnumerable<Card> GetLastRoundCards(long gameId)
        {
            IEnumerable<Card> cards = _dbContext.RoundPlayers
                .Where(roundPlayer => roundPlayer.GameId == gameId && roundPlayer.CreationTime ==
                    _dbContext.RoundPlayers
                        .Where(tmpRoundPlayer => tmpRoundPlayer.GameId == gameId)
                        .Max(tmpRoundPlayer => tmpRoundPlayer.CreationTime))
                .Include(roundPlayer => roundPlayer.Cards)
                .ThenInclude(roundPlayerCard => roundPlayerCard.Card)
                .SelectMany(roundPlayer => roundPlayer.Cards.Select(roundPlayerCard => roundPlayerCard.Card));
            return cards;
        }

        public IEnumerable<Card> GetLastRoundPlayerCards(long playerId, long gameId)
        {
            IEnumerable<Card> playerCards = _dbContext.RoundPlayerCards
                .Where(roundPlayerCard => roundPlayerCard.RoundPlayerId == _dbContext.RoundPlayers
                    .Where(roundPlayer => roundPlayer.PlayerId == playerId && roundPlayer.GameId == gameId)
                    .OrderByDescending(roundPlayer => roundPlayer.CreationTime)
                    .First()
                    .Id)
                .Include(roundPlayerCard => roundPlayerCard.Card)
                .Select(roundPlayerCard => roundPlayerCard.Card);
            return playerCards;
        }
    }
}
