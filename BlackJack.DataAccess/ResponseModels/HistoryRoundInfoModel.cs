using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class HistoryRoundInfoModel
    {
        public string PlayerName { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
