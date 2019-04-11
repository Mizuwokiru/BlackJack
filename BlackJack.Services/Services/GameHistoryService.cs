using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Http;

namespace BlackJack.Services.Services
{
    public class GameHistoryService : IGameHistoryService
    {
        private readonly IGameRepository _gameRepository;
        private readonly Player _user;

        public GameHistoryService(IPlayerRepository playerRepository,
            IGameRepository gameRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _user = playerRepository.GetUser(httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public IEnumerable<HistoryGameViewModel> GetGamesHistory()
        {
            IEnumerable<HistoryGameInfoModel> historyGamesInfo = _gameRepository.GetGamesHistory(_user.Id);

            IEnumerable<HistoryGameViewModel> historyGameViewModels = historyGamesInfo.Select(historyGameInfo => new HistoryGameViewModel
            {
                RoundCount = historyGameInfo.RoundCount,
                PlayerCount = historyGameInfo.PlayerCount,
                CreationTime = historyGameInfo.CreationTime
            });

            return historyGameViewModels;
        }
    }
}
