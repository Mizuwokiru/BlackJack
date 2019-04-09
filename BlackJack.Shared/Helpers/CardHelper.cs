using BlackJack.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Shared.Helpers
{
    public static class CardHelper
    {
        public const int BlankCard = 0x1F0A0;

        public static int GetCard(Suit suit, Rank rank)
        {
            int card = BlankCard + ((int)suit - 1) * 0x10 + (int)rank;
            if (rank >= Rank.Queen)
            {
                card++;
            }
            return card;
        }

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
    }
}
