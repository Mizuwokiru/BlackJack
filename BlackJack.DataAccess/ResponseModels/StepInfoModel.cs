using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class StepInfoModel
    {
        public long UserRoundId { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}
