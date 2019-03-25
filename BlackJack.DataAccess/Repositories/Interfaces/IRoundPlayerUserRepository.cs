using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundPlayerUserRepository : IRepository<RoundPlayerUser>
    {
        RoundPlayerUser GetRoundPlayerUserByRound(int roundId);
    }
}
