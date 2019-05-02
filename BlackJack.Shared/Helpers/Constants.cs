using BlackJack.Shared.Enums;
using System;

namespace BlackJack.Shared.Helpers
{
    public static class Constants
    {
        public const long DealerId = 1;

        public static readonly int SuitCount = Enum.GetValues(typeof(Suit)).Length;
        public static readonly int RankCount = Enum.GetValues(typeof(Rank)).Length;
        public static readonly int CardCount = SuitCount * RankCount;

        public const int MaxBotCount = 7;

        public const int AceSecondaryValue = 1;
        public const int BlackJackValue = 21;
        public const int DealerStopValue = 17;

        public const int BlankCardCode = 0x1F0A0;

        public const string ClaimPlayerId = "player_id";
    }
}
