using System.Collections.Generic;

namespace BlackJack.Services.Services
{
    class GameSession
    {
        public long GameId { get; set; }

        public List<long> ShuffledCards { get; set; }
    }
}
