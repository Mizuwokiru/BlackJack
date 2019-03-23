using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>, IRoundPlayerRepository
    {
        public RoundPlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
