using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IRoundRepository _roundRepository;
        private readonly Player _user;

        public GameHistoryService(IPlayerRepository playerRepository,
            IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _user = playerRepository.GetUser(httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public IEnumerable<HistoryGameViewModel> GetGamesHistory()
        {
            IEnumerable<HistoryGameInfoModel> historyGamesInfo = _gameRepository.GetGamesHistory(_user.Id);

            IEnumerable<HistoryGameViewModel> historyGameViewModels =
                Mapper.Map<IEnumerable<HistoryGameInfoModel>, IEnumerable<HistoryGameViewModel>>(historyGamesInfo);

            return historyGameViewModels;
        }

        public IEnumerable<IEnumerable<HistoryRoundViewModel>> GetRoundsHistory(int gameOrder)
        {
            IEnumerable<IEnumerable<HistoryRoundInfoModel>> historyRoundsInfo = _roundRepository.GetHistoryRoundsInfo(_user.Id, gameOrder);
            IEnumerable<IEnumerable<HistoryRoundViewModel>> historyRoundViewModels =
                Mapper.Map<IEnumerable<IEnumerable<HistoryRoundInfoModel>>, IEnumerable<IEnumerable<HistoryRoundViewModel>>>(historyRoundsInfo);
            return historyRoundViewModels;
        }
    }
}
