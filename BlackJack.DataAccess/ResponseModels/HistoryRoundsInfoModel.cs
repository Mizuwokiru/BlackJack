using System.Collections.Generic;

namespace BlackJack.DataAccess.ResponseModels
{
    public class HistoryRoundsInfoModel
    {
        public IEnumerable<HistoryRoundInfoModel> Players { get; set; }
    }
}
