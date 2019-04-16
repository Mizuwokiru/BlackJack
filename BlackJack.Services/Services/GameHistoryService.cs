﻿using System.Collections.Generic;
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

        public IEnumerable<GameViewModel> GetGamesHistory()
        {
            IEnumerable<HistoryGameInfoModel> historyGamesInfo = _gameRepository.GetGamesHistory(_user.Id);

            IEnumerable<GameViewModel> historyGameViewModels =
                Mapper.Map<IEnumerable<HistoryGameInfoModel>, IEnumerable<GameViewModel>>(historyGamesInfo);

            return historyGameViewModels;
        }

        public GameRoundsViewModel GetRoundsHistory(int gameSkipCount)
        {
            IEnumerable<RoundState> roundStates = _roundRepository.GetRoundStates(_user.Id, gameSkipCount);
            var gameRoundsViewModel = new GameRoundsViewModel { RoundStates = roundStates };
            return gameRoundsViewModel;
        }

        public IEnumerable<RoundViewModel> GetRoundInfo(int gameSkipCount, int roundSkipCount)
        {
            IEnumerable<RoundInfoModel> roundInfos = _roundRepository.GetRoundInfo(_user.Id, gameSkipCount, roundSkipCount);
            IEnumerable<RoundViewModel> roundViewModels = Mapper.Map<IEnumerable<RoundInfoModel>, IEnumerable<RoundViewModel>>(roundInfos);
            return roundViewModels;
        }
    }
}
