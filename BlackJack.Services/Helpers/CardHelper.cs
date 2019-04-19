using BlackJack.DataAccess.Entities;
using BlackJack.Shared;
using BlackJack.Shared.Enums;

namespace BlackJack.Services.Helpers
{
    public static class CardHelper
    {
        public static int GetCardScore(Rank rank)
        {
            if (rank >= Rank.Ten && rank <= Rank.King)
            {
                return 10;
            }
            if (rank == Rank.Ace)
            {
                return 11;
            }
            return (int)rank;
        }

        public static Card GetCardById(long id)
        {
            Suit suit = (Suit)((id - 1) / BlackJackConstants.RankCount + 1);
            Rank rank = (Rank)((id - 1) % BlackJackConstants.RankCount + 1);
            Card card = new Card { Id = id, Suit = suit, Rank = rank };
            return card;
        }
    }
}
