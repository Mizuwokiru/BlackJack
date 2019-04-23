using AutoMapper;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Helpers;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Services.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly long _userId;

        public HistoryService(IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            string playerIdClaimValue = httpContextAccessor.HttpContext.User.FindFirst(Constants.ClaimPlayerId).Value;
            if (!string.IsNullOrEmpty(playerIdClaimValue))
            {
                _userId = long.Parse(playerIdClaimValue);
            }
        }

        public GamesHistoryViewModel GetGamesHistory()
        {
            IEnumerable<GamesHistoryInfoModel> gamesHistoryInfo = _gameRepository.GetGamesHistory(_userId);
            var gamesHistory = new GamesHistoryViewModel
            {
                Games = Mapper.Map<IEnumerable<GamesHistoryInfoModel>, IEnumerable<GameViewModel>>(gamesHistoryInfo)
            };
            return gamesHistory;
        }

        public RoundsHistoryViewModel GetRoundsHistory(int gameSkipCount)
        {
            IEnumerable<RoundState> roundStates = _roundRepository.GetRoundStates(_userId, gameSkipCount);
            var gameRoundsViewModel = new RoundsHistoryViewModel { RoundStates = roundStates };
            return gameRoundsViewModel;
        }

        public RoundInfoViewModel GetRoundInfo(int gameSkipCount, int roundSkipCount)
        {
            IEnumerable<RoundInfoModel> roundInfos = _roundRepository.GetRoundInfo(_userId, gameSkipCount, roundSkipCount);
            List<PlayerStateViewModel> players = Mapper.Map<IEnumerable<RoundInfoModel>, IEnumerable<PlayerStateViewModel>>(roundInfos).ToList();
            if (players[0].State == RoundState.None)
            {
                PlayerStateViewModel dealer = players[players.Count - 1];
                dealer.Cards[1] = Constants.BlankCardCode;
                dealer.Score = 0;
            }
            var roundInfo = new RoundInfoViewModel
            {
                Players = players
            };
            return roundInfo;
        }
    }
}
