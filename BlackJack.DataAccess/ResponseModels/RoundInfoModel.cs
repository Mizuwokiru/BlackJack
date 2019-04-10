using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class RoundInfoModel
    {
        public long RoundId { get; set; }

        public PlayerModel Player { get; set; }

        public List<CardModel> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
