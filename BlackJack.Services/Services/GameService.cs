﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly string _userName;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            ICardRepository cardRepository,
            IRoundCardRepository roundCardRepository,
            HttpContext httpContext)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundCardRepository = roundCardRepository;
            _userName = httpContext.User.Identity.Name;
        }

        public void NewGame(int botCount)
        {
            Player user = _playerRepository.GetUser(_userName);
            FinishGame(user.Id);

            var game = new Game();
            _gameRepository.Add(game);

            var playerList = new List<Player> { user };
            var bots = _playerRepository.GetBots();
            int availableBotCount = bots.Count();
            if (availableBotCount < botCount)
            {

            }
        }

        public void ContinueGame()
        {
            throw new System.NotImplementedException();
        }

        public void EndGame()
        {
            throw new System.NotImplementedException();
        }

        public void NextRound()
        {
            throw new System.NotImplementedException();
        }

        public void Skip()
        {
            throw new System.NotImplementedException();
        }

        public void Step()
        {
            throw new System.NotImplementedException();
        }

        #region Private methods
        private void FinishGame(long userId)
        {
            Game game = _gameRepository.GetUnfinishedGame(userId);
            if (game != null)
            {
                game.IsFinished = true;
                _gameRepository.Update(game);
            }
        }

        private void FinishRound(long gameId)
        {

        }

        private IEnumerable<Player> CreateBots(int availableBotCount, int neededBotCount)
        {

        }
        #endregion
    }
}
