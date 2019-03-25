using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class BotRepository : BaseRepository<Bot>, IBotRepository
    {
        public BotRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Bot> GetOrCreateBots(int botCount)
        {
            List<Bot> bots = (List<Bot>) GetAll();
            if (bots.Count < botCount)
            {
                for (int i = bots.Count; i < botCount; i++)
                {
                    var bot = new Bot { Name = $"Bot #{i + 1}" };
                    Add(bot);
                    bots.Add(bot);
                }
            }
            return bots.GetRange(0, botCount);
        }

        public IEnumerable<Bot> GetBotsWithIds(IEnumerable<int> botsIds)
        {
            var bots = new List<Bot>();
            foreach (var botId in botsIds)
            {
                bots.Add(Get(botId));
            }
            return bots;
        }
    }
}
