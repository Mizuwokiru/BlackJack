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
        private readonly ICardRepository _cardRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly long _userId;

        public HistoryService(ICardRepository cardRepository,
            IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _cardRepository = cardRepository;
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
                Games = Mapper.Map<IEnumerable<GamesHistoryInfoModel>, IEnumerable<GameGamesHistoryViewModel>>(gamesHistoryInfo)
            };
            return gamesHistory;
        }

        public RoundsHistoryViewModel GetRoundsHistory(int gameSkipCount)
        {
            IEnumerable<RoundState> roundStates = _roundRepository.GetRoundStates(_userId, gameSkipCount);
            var gameRoundsViewModel = new RoundsHistoryViewModel { RoundStates = roundStates };
            return gameRoundsViewModel;
        }

        public GameViewModel GetRoundInfo(int gameSkipCount, int roundSkipCount)
        {
            long gameId = _gameRepository.GetGameIdBySkipCount(_userId, gameSkipCount);
            IEnumerable<RoundInfoModel> roundInfos = _roundRepository.GetRoundInfo(_userId, gameId, roundSkipCount).ToList();
            _cardRepository.GetRoundCards(roundInfos);
            List<PlayerGameViewModel> players = Mapper.Map<IEnumerable<RoundInfoModel>, IEnumerable<PlayerGameViewModel>>(roundInfos).ToList();
            if (players[0].State == RoundState.None)
            {
                PlayerGameViewModel dealer = players[players.Count - 1];
                dealer.Cards[1] = Constants.BlankCardCode;
                dealer.Score = 0;
            }
            var roundInfo = new GameViewModel
            {
                Players = players
            };
            return roundInfo;
        }
    }
}
