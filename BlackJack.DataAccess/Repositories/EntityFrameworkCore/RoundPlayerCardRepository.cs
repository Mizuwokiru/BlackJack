using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerCardRepository : BaseRepository<RoundPlayerCard>, IRoundPlayerCardRepository
    {
        public RoundPlayerCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
