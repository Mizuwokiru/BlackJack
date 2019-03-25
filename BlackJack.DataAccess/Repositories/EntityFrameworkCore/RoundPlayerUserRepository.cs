using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerUserRepository : BaseRepository<RoundPlayerUser>, IRoundPlayerUserRepository
    {
        public RoundPlayerUserRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public RoundPlayerUser GetRoundPlayerUserByRound(int roundId) =>
            _dbContext.Set<RoundPlayerUser>().Where(roundPlayerUser => roundPlayerUser.Round.Id == roundId).FirstOrDefault();
    }
}
