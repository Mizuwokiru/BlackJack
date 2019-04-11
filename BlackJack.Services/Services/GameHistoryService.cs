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

            IEnumerable<HistoryGameViewModel> historyGameViewModels = historyGamesInfo.Select(historyGameInfo => new HistoryGameViewModel
            {
                RoundCount = historyGameInfo.RoundCount,
                PlayerCount = historyGameInfo.PlayerCount,
                CreationTime = historyGameInfo.CreationTime
            });

            return historyGameViewModels;
        }

        public IEnumerable<HistoryRoundsViewModel> GetRoundsHistory(int gameOrder)
        {
            IEnumerable<HistoryRoundsInfoModel> historyRoundsInfo = _roundRepository.GetHistoryRoundsInfo(_user.Id, gameOrder);

            IEnumerable<HistoryRoundsViewModel> historyRoundsViewModels = historyRoundsInfo
                .Select(roundsInfo => new HistoryRoundsViewModel
                {
                    Players = roundsInfo.Players.Select(player => new HistoryRoundViewModel
                    {
                        PlayerName = player.PlayerName,
                        Cards = player.Cards.Select(card => new CardViewModel
                        {
                            Suit = card.Suit,
                            Rank = card.Rank
                        }),
                        State = player.State
                    }).ToList()
                });

            return historyRoundsViewModels;
        }
    }
}
