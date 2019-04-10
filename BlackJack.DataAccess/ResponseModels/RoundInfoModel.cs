using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class RoundInfoModel
    {
        public long RoundId { get; set; }

        public string PlayerName { get; set; }

        public PlayerType PlayerType { get; set; }

        public List<Card> Cards { get; set; }

        public RoundState RoundState { get; set; }
    }
}
