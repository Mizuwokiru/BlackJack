using System;

namespace BlackJack.DataAccess.ResponseModels
{
    public class GamesHistoryInfoModel
    {
        public int RoundCount { get; set; }

        public int PlayerCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
