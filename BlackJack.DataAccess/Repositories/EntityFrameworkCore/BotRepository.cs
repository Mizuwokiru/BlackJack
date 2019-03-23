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
    }
}
