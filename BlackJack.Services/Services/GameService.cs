﻿using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly ICardRepository _cardRepository;

        private readonly IMemoryCache _cache;

        public GameService(IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IRoundRepository roundRepository,
            IRoundCardRepository roundCardRepository,
            ICardRepository cardRepository,
            IMemoryCache cache)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _roundCardRepository = roundCardRepository;
            _cardRepository = cardRepository;

            _cache = cache;
        }

        public GameViewModel ContinueGame(long userId)
        {
            Game game = _gameRepository.GetUnfinishedGame(userId);
            if (game == null)
            {
                throw new InvalidOperationException($"Unfinished games for user {userId} is not found");
            }
            IEnumerable<Player> players = _playerRepository.GetPlayersForGame(game.Id);
            IEnumerable<PlayerViewModel> playerViewModels =
                players.Select(player => new PlayerViewModel { PlayerId = player.Id, PlayerName = player.Name });

            var continuedGame = new GameViewModel { GameId = game.Id, Players = playerViewModels };
            return continuedGame;
        }

        public GameViewModel CreateGame(long userId, int botCount)
        {
            _gameRepository.FinishAllGames(userId);
            if (botCount < 0 || botCount > BlackJackConstants.MaxBotCount)
            {
                throw new ArgumentOutOfRangeException($"Bot count {botCount} is too much");
            }

            var game = new Game();
            _gameRepository.Add(game);

            var players = new List<Player>();
            Player user = _playerRepository.Get(userId);
            players.Add(user);
            List<Player> bots = _playerRepository.GetBots(botCount).ToList();
            players.AddRange(bots);
            if (bots.Count < botCount)
            {
                List<Player> addedBots = AddBots(bots.Count, botCount);
                players.AddRange(addedBots);
            }
            Player dealer = _playerRepository.GetDealer();
            players.Add(dealer);

            var rounds = new List<Round>();
            var playerViewModels = new List<PlayerViewModel>();
            foreach (var player in players)
            {
                var round = new Round { GameId = game.Id, PlayerId = player.Id };
                rounds.Add(round);

                var playerViewModel = new PlayerViewModel { PlayerId = player.Id, PlayerName = player.Name };
                playerViewModels.Add(playerViewModel);
            }
            _roundRepository.Add(rounds);

            var createdGame = new GameViewModel { GameId = game.Id, Players = playerViewModels };
            return createdGame;
        }

        public void FinishGame(long gameId)
        {
            throw new System.NotImplementedException();
        }

        public FinishRoundViewModel FinishRound(long gameId)
        {
            List<Round> rounds = _roundRepository.GetLastRounds(gameId).ToList();



            throw new System.NotImplementedException();
        }

        public GetCardViewModel GetCard(long gameId)
        {
            Round round = _roundRepository.GetLastRound(gameId);

            List<Card> cards = _cardRepository.GetCards(round.Id).ToList();

            int score = CalculateCardScore(cards);
            if (score > 21)
            {
                throw new InvalidOperationException("User already lose.");
            }

            var shuffledCards = (List<long>)_cache.Get(gameId);
            Card takenCard = _cardRepository.Get(shuffledCards[0]);
            var roundCard = new RoundCard { RoundId = round.Id, CardId = takenCard.Id };
            _roundCardRepository.Add(roundCard);
            shuffledCards.RemoveAt(0);

            score += GetCardScore(takenCard);

            var cardViewModel = new CardViewModel { Suit = takenCard.Suit, Rank = takenCard.Rank };

            var getCardViewModel = new GetCardViewModel { CanToTakeMore = score < 21, Card = cardViewModel };

            return getCardViewModel;
        }

        public PlayersCardsViewModel GetRound(long gameId)
        {
            List<Round> rounds = _roundRepository.GetLastRounds(gameId).ToList();

            List<long> shuffledCards = GetShuffledCards();

            List<RoundCard> roundCards = null;
            if (!_roundCardRepository.HasAnyCard(gameId))
            {
                roundCards = GetInitialCards(rounds, shuffledCards);
            }
            if (roundCards == null)
            {
                roundCards = GetAvailableCards(rounds);
            }

            IEnumerable<IGrouping<long, RoundCard>> cardsByRounds = roundCards
                .GroupBy(roundCard => roundCard.RoundId);

            int userCardsScore = 0;
            var playerCardsViewModels = new List<PlayerCardsViewModel>();
            foreach (var cardsByRound in cardsByRounds)
            {
                List<Card> cards = _cardRepository.GetCards(cardsByRound.Key).ToList();
                List<CardViewModel> cardViewModels = cards
                    .Select(card =>
                    {
                        shuffledCards.Remove(card.Id);
                        var cardViewModel = new CardViewModel { Suit = card.Suit, Rank = card.Rank };
                        return cardViewModel;
                    }).ToList();
                Player player = _playerRepository.GetPlayer(cardsByRound.Key);
                if (player.Type == PlayerType.Dealer)
                {
                    cardViewModels.RemoveAt(cardViewModels.Count - 1);
                }
                if (player.Type == PlayerType.User)
                {
                    userCardsScore = CalculateCardScore(cards);
                }
                var playerCardsViewModel =
                    new PlayerCardsViewModel { PlayerId = player.Id, Cards = cardViewModels };
                playerCardsViewModels.Add(playerCardsViewModel);
            }
            _cache.Set(gameId, shuffledCards);

            var playersCardsViewModel =
                new PlayersCardsViewModel { CanToTakeMore = userCardsScore < 21, PlayersCards = playerCardsViewModels };

            return playersCardsViewModel;
        }

        public bool HasUnfinishedGames(long userId)
        {
            bool hasUnfinishedGames = _gameRepository.HasUnfinishedGames(userId);
            return hasUnfinishedGames;
        }

        #region Private methods
        private List<Player> AddBots(int availableBotCount, int neededBotCount)
        {
            var bots = new List<Player>();
            for (int i = availableBotCount; i < neededBotCount; i++)
            {
                var bot = new Player { Name = $"Bot №{i + 1}", Type = PlayerType.Bot };
                bots.Add(bot);
            }
            _playerRepository.Add(bots);
            return bots;
        }

        private List<RoundCard> GetInitialCards(List<Round> rounds, List<long> shuffledCards)
        {
            var roundCardsToDb = new List<RoundCard>();
            for (int i = 0; i < rounds.Count; i++)
            {
                
                roundCardsToDb.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i] });
                roundCardsToDb.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i + rounds.Count] });
            }
            _roundCardRepository.Add(roundCardsToDb);
            return roundCardsToDb;
        }

        private List<RoundCard> GetAvailableCards(List<Round> rounds)
        {
            var availableCards = new List<RoundCard>();
            foreach (var round in rounds)
            {
                IEnumerable<RoundCard> cards = _roundCardRepository.GetCards(round.Id);
                availableCards.AddRange(cards);
            }
            return availableCards;
        }

        private static int CalculateCardScore(List<Card> cards)
        {
            int score = 0;
            foreach (var card in cards)
            {
                score += GetCardScore(card);
            }
            while (score > 21)
            {
                var ace = cards.Where(card => card.Rank == Rank.Ace).FirstOrDefault();
                if (ace == null)
                {
                    break;
                }
                cards.Remove(ace);
                score -= 10;
            }
            return score;
        }

        private static int GetCardScore(Card card)
        {
            if (card.Rank >= Rank.Ten && card.Rank <= Rank.King)
            {
                return 10;
            }
            if (card.Rank == Rank.Ace)
            {
                return 11;
            }
            return (int)card.Rank;
        }

        private static List<long> GetShuffledCards()
        {
            var cards = Enumerable.Range(1, BlackJackConstants.DeckCapacity)
                .Select(value => (long)value)
                .ToList();

            var random = new Random();
            for (int i = cards.Count - 1, j; i > 0; i--)
            {
                j = random.Next(i + 1);
                long tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }

            return cards;
        }
        #endregion
    }
}
