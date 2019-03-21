using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.BusinessLogic.Utils;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGamePlayerRepository _gamePlayerRepository;
        private readonly IRoundPlayerRepository _roundPlayerRepository;
        private readonly ICardRepository _cardRepository;

        public GameService(IGameRepository gameRepository,
            IRoundRepository roundRepository,
            IPlayerRepository playerRepository,
            IGamePlayerRepository gamePlayerRepository,
            IRoundPlayerRepository roundPlayerRepository,
            ICardRepository cardRepository)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _playerRepository = playerRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _roundPlayerRepository = roundPlayerRepository;
            _cardRepository = cardRepository;
        }

        public RoundCreationViewModel CreateRound(int gameId)
        {
            Game game = _gameRepository.Get(gameId);
            if (game == null)
            {
                throw new ValidationException("Game not exists.");
            }

            IEnumerable<Player> players = _gamePlayerRepository.GetGamePlayers(gameId).Select(gamePlayer => gamePlayer.Player);

            List<Round> rounds = _roundRepository.GetRounds(gameId).ToList();

            var round = new Round { Game = game, Number = rounds.Count + 1 };
            _roundRepository.Create(round);

            foreach (var player in players)
            {
                _roundPlayerRepository.Create(new RoundPlayer { Round = round, Player = player });
            }

            return new RoundCreationViewModel { RoundId = round.Id, Players = Mapper.MapPlayers(players) };
        }

        private List<CardViewModel> ShuffleCards(List<CardViewModel> sortedCards)
        {
            var shuffledCards = new List<CardViewModel>();
            var random = new Random();
            var initialCount = sortedCards.Count;
            for (int i = 0; i < initialCount; i++)
            {
                int shuffleCardIndex = random.Next(sortedCards.Count);
                shuffledCards.Add(sortedCards[shuffleCardIndex]);
                sortedCards.RemoveAt(shuffleCardIndex);
            }

            return shuffledCards;
        }

        public IEnumerable<CardViewModel> GetShuffledCards()
        {
            var allCards = Mapper.MapCards(_cardRepository.GetAll());
            var sortedCards = new List<CardViewModel>();
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                sortedCards.AddRange(allCards);
            }
            return ShuffleCards(sortedCards);
        }
    }
}
