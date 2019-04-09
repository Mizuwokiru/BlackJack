using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BlackJack.Services.Services
{
    public class GameHistoryService : IGameHistoryService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly Player _user;

        public GameHistoryService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            ICardRepository cardRepository,
            IRoundCardRepository roundCardRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundCardRepository = roundCardRepository;
            _user = _playerRepository.GetUser(httpContextAccessor.HttpContext.User.Identity.Name);
        }

        // TODO: Get short info of games
        // TODO: Get detail info of concrete game
        // with pagination?
    }
}
