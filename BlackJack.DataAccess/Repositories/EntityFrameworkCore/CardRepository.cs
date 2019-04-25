using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(GameDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Card> GetPlayerCards(long playerId, long gameId)
        {
            IEnumerable<Card> cards = _dbContext.RoundCards
                .Where(roundCard => roundCard.RoundId ==
                    _dbContext.Rounds
                        .First(round => round.PlayerId == playerId && round.GameId == gameId && round.CreationTime ==
                            _dbContext.Rounds
                                .Where(tmpRound => tmpRound.PlayerId == playerId && tmpRound.GameId == gameId)
                                .Max(tmpRound => tmpRound.CreationTime))
                                .Id)
                .Select(roundCard => roundCard.Card);

            return cards;
        }

        public void GetRoundCards(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            foreach (var roundInfoModel in roundInfoModels)
            {
                List<Card> cards = _dbContext.RoundCards
                    .Where(roundCard => roundCard.RoundId == roundInfoModel.RoundId)
                    .Select(roundCard => roundCard.Card)
                    .ToList();
                roundInfoModel.Cards = cards;
            }
        }
    }
}
