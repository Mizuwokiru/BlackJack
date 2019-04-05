using BlackJack.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Shared.Helpers
{
    public static class CardHelper
    {
        public static readonly string StringifiedBlankCard = char.ConvertFromUtf32(BlackJackConstants.BlankCardUtf32);

        public static string StringifyCard(Suit suit, Rank rank)
        {
            int utf32 = BlackJackConstants.BlankCardUtf32 + ((int)suit - 1) * 0x10 + (int)rank;
            if (rank >= Rank.Queen)
            {
                utf32++;
            }
            return char.ConvertFromUtf32(utf32);
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

        public static List<long> GetShuffledCards()
        {
            var cards = new List<long>();
            for (int i = 0; i < BlackJackConstants.DeckCount; i++)
            {
                IEnumerable<long> deck = Enumerable.Range(1, BlackJackConstants.DeckCapacity)
                    .Select(cardId => (long) cardId);
                cards.AddRange(deck);
            }

            if (cards.Count == 0)
            {
                throw new InvalidOperationException("WTF?");
            }

            var random = new Random();
            for (int i = cards.Count - 1, j; i > 0; i--)
            {
                j = random.Next(i + 1);
                long tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }

            return cards;
        }
    }
}
