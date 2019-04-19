using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.ViewModels.Models.Game;
using BlackJack.ViewModels.Models.History;
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

        public HistoryRoundsViewModel GetRoundsHistory(int gameSkipCount)
        {
            IEnumerable<RoundState> roundStates = _roundRepository.GetRoundStates(_user.Id, gameSkipCount);
            var gameRoundsViewModel = new HistoryRoundsViewModel { RoundStates = roundStates };
            return gameRoundsViewModel;
        }

        public RoundInfoViewModel GetRoundInfo(int gameSkipCount, int roundSkipCount)
        {
            IEnumerable<RoundInfoModel> roundInfos = _roundRepository.GetRoundInfo(_user.Id, gameSkipCount, roundSkipCount);
            IEnumerable<RoundViewModel> roundViewModels = Mapper.Map<IEnumerable<RoundInfoModel>, IEnumerable<RoundViewModel>>(roundInfos);
            RoundViewModel user = roundViewModels.Where(roundViewModel => roundViewModel.PlayerType == PlayerType.User).First();
            RoundViewModel dealer = roundViewModels.Where(roundViewModel => roundViewModel.PlayerType == PlayerType.Dealer).First();
            if (user.State == RoundState.None)
            {
                dealer.Cards.RemoveAt(1);
            }
            var roundInfo = new RoundInfoViewModel
            {
                User = user,
                Dealer = dealer,
                Bots = roundViewModels.Except(new[] { user, dealer })
            };
            return roundInfo;
        }
    }
}
