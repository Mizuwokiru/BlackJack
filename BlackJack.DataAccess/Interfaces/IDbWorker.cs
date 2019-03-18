using BlackJack.DataAccess.Repositories;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IDbWorker
    {
        CardRepository Cards { get; }

        GameRepository Games { get; }

        PlayerRepository Players { get; }

        GamePlayerRepository GamePlayers { get; }

        RoundRepository Rounds { get; }

        RoundPlayerRepository RoundPlayers { get; }

        RoundPlayerCardRepository RoundPlayerCards { get; }

        void Save();
    }
}
