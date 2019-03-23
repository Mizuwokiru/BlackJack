using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerBotRepository : BaseRepository<RoundPlayerBot>, IRoundPlayerBotRepository
    {
        public RoundPlayerBotRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
