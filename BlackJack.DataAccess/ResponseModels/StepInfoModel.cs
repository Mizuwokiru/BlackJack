using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class StepInfoModel
    {
        public long UserRoundId { get; set; }

        public RoundState UserState { get; set; }

        public IEnumerable<Card> RoundsCards { get; set; }
    }
}
