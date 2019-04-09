using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Helpers;
using BlackJack.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlackJack.Services.Services
{
    public class RoundService : IRoundService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly Player _user;

        public RoundService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            ICardRepository cardRepository,
            IRoundCardRepository roundCardRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _roundCardRepository = roundCardRepository;
            _user = _playerRepository.GetUser(httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public List<RoundViewModel> GetRoundsInfo()
        {
            Game game = _gameRepository.GetUnfinishedGame(_user.Id);
            List<Round> lastRounds = _roundRepository.GetLastRounds(game.Id);

            var roundViewModels = new List<RoundViewModel>();
            foreach (var round in lastRounds)
            {
                RoundViewModel roundViewModel = GetRoundInfo(round);
                roundViewModels.Add(roundViewModel);
            }

            return roundViewModels;
        }

        public void CreateRound()
        {

        }

        public void Step()
        {

        }

        public void Skip()
        {

        }

        public void NextRound()
        {

        }

        #region Private methods
        private RoundViewModel GetRoundInfo(Round round)
        {
            Player player = _playerRepository.GetPlayer(round.Id);
            PlayerViewModel playerViewModel = new PlayerViewModel { Name = player.Name, Type = player.Type };

            List<Card> cards = _cardRepository.GetCards(round.Id);
            List<CardViewModel> cardViewModels = new List<CardViewModel>();
            foreach (var card in cards)
            {
                var cardViewModel = new CardViewModel { Card = CardHelper.GetCard(card.Suit, card.Rank) };
                cardViewModels.Add(cardViewModel);
            }
            if (round.PlayerId == BlackJackConstants.DealerId && cards.Count == 2)
            {
                cardViewModels[1].Card = CardHelper.BlankCard;
            }

            var roundViewModel = new RoundViewModel { Player = playerViewModel, Cards = cardViewModels, State = round.State };
            return roundViewModel;
        }
        #endregion
    }
}
