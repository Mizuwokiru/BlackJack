using BlackJack.DataAccess.EF;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;

namespace BlackJack.DataAccess
{
    public class DbWorker : IDbWorker
    {
        private GameContext _gameContext;

        private CardRepository _cardRepository;
        private GameRepository _gameRepository;
        private PlayerRepository _playerRepository;
        private GamePlayerRepository _gamePlayerRepository;
        private RoundRepository _roundRepository;
        private RoundPlayerRepository _roundPlayerRepository;
        private RoundPlayerCardRepository _roundPlayerCardRepository;

        public CardRepository Cards
        {
            get
            {
                if (_cardRepository == null)
                {
                    _cardRepository = new CardRepository(_gameContext);
                }
                return _cardRepository;
            }
        }

        public GameRepository Games
        {
            get
            {
                if (_gameRepository == null)
                {
                    _gameRepository = new GameRepository(_gameContext);
                }
                return _gameRepository;
            }
        }

        public PlayerRepository Players
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(_gameContext);
                }
                return _playerRepository;
            }
        }

        public GamePlayerRepository GamePlayers
        {
            get
            {
                if (_gamePlayerRepository == null)
                {
                    _gamePlayerRepository = new GamePlayerRepository(_gameContext);
                }
                return _gamePlayerRepository;
            }
        }

        public RoundRepository Rounds
        {
            get
            {
                if (_roundRepository == null)
                {
                    _roundRepository = new RoundRepository(_gameContext);
                }
                return _roundRepository;
            }
        }

        public RoundPlayerRepository RoundPlayers
        {
            get
            {
                if (_roundPlayerRepository == null)
                {
                    _roundPlayerRepository = new RoundPlayerRepository(_gameContext);
                }
                return _roundPlayerRepository;
            }
        }

        public RoundPlayerCardRepository RoundPlayerCards
        {
            get
            {
                if (_roundPlayerCardRepository == null)
                {
                    _roundPlayerCardRepository = new RoundPlayerCardRepository(_gameContext);
                }
                return _roundPlayerCardRepository;
            }
        }

        public DbWorker(string connectionString)
        {
            _gameContext = new GameContext(connectionString);
        }

        public void Save()
        {
            _gameContext.SaveChanges();
        }
    }
}
