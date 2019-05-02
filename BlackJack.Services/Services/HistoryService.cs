using AutoMapper;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
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
        private readonly IRoundPlayerRepository _roundRepository;
        private readonly long _userId;

        public HistoryService(ICardRepository cardRepository,
            IGameRepository gameRepository,
            IRoundPlayerRepository roundRepository,
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
            List<Game> gamesHistoryInfo = _gameRepository.GetGamesHistory(_userId).ToList();
            var gamesHistory = new GamesHistoryViewModel
            {
                Games = Mapper.Map<List<Game>, IEnumerable<GameGamesHistoryViewModel>>(gamesHistoryInfo)
            };
            return gamesHistory;
        }

        public RoundsHistoryViewModel GetRoundsHistory(int gameSkipCount)
        {
            IEnumerable<RoundPlayerState> roundStates = _gameRepository.GetGameInfo(_userId, gameSkipCount).ToList();
            var gameRoundsViewModel = new RoundsHistoryViewModel { PlayerStates = roundStates };
            return gameRoundsViewModel;
        }

        public GameViewModel GetRoundInfo(int gameSkipCount, int roundSkipCount)
        {
            long gameId = _gameRepository.GetGameIdBySkipCount(_userId, gameSkipCount);
            List<RoundPlayer> roundPlayers = _roundRepository.GetRoundInfo(gameId, roundSkipCount).ToList();
            _cardRepository.FillRoundPlayersCards(roundPlayers);
            List<PlayerGameViewModel> players = Mapper.Map<List<RoundPlayer>, List<PlayerGameViewModel>>(roundPlayers);
            if (players[0].State == RoundPlayerState.None)
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
