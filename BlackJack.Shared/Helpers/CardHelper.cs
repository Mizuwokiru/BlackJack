using BlackJack.Shared.Enums;
using System;

namespace BlackJack.Shared.Helpers
{
    public static class CardHelper
    {
        public static Tuple<Suit, Rank> GetCardById(long id)
        {
            Suit suit = (Suit)((id - 1) / Constants.RankCount + 1);
            Rank rank = (Rank)((id - 1) % Constants.RankCount + 1);
            return Tuple.Create(suit, rank);
        }

        public static int GetValue(this Rank rank)
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

        public static int GetCardCode(Suit suit, Rank rank)
        {
            int cardCode = Constants.BlankCardCode + ((int)suit - 1) * 0x10 + (int)rank;
            if (rank >= Rank.Queen)
            {
                cardCode++;
            }
            return cardCode;
        }
    }
}
