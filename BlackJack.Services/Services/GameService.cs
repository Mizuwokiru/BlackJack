using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Extensions;
using BlackJack.Shared.Helpers;
using BlackJack.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IRoundCardRepository _roundCardRepository;
        private readonly ISession _session;
        private readonly string _userName;

        public GameService(IGameRepository gameRepository,
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
            _session = httpContextAccessor.HttpContext.Session;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<bool> CanToContinueGame()
        {
            Player user = await _playerRepository.GetPlayer(_userName);
            Task<bool> canToContinueGame = _gameRepository.CanToContinueGame(user.Id);
            return await canToContinueGame;
        }

        public async Task ContinueGame()
        {
            Player user = await _playerRepository.GetPlayer(_userName);
            Game unfinishedGame = await _gameRepository.GetUnfinishedGame(user.Id);
            if (unfinishedGame == null)
            {
                throw new InvalidOperationException($"Unfinished games for user \'{_userName}\' is not found");
            }
            var gameSession = new GameSession { GameId = unfinishedGame.Id };
            _session.Set(_userName, gameSession);
        }

        public Task<List<GamePlayerInfoViewModel>> GetGameInfo()
        {
            throw new NotImplementedException();
        }

        public async Task NewGame(int botCount)
        {
            if (botCount < 0 || botCount > BlackJackConstants.MaxBotCount)
            {
                throw new ArgumentOutOfRangeException($"Bot count {botCount} is too much");
            }

            Player user = await _playerRepository.GetPlayer(_userName);
            Game unfinishedGame = await _gameRepository.GetUnfinishedGame(user.Id);
            if (unfinishedGame != null)
            {
                await FinishRound(unfinishedGame.Id);
                FinishGame(unfinishedGame);
            }

            var game = new Game();
            _gameRepository.Add(game);

            await CreateNextRound(game.Id, botCount);
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

        private void FinishGame(Game game)
        {
            game.IsFinished = true;
            _gameRepository.Update(game);
        }

        private async Task FinishRound(long gameId)
        {
            Player user = await _playerRepository.GetPlayer(_userName);
            Round userRound = await _roundRepository.GetLastRound(gameId, user.Id);
            if (userRound.State != RoundState.None)
            {
                return;
            }
            List<Round> rounds = await _roundRepository.GetLastRounds(gameId);
            Player dealer = await _playerRepository.GetDealer();
            Round dealerRound = await _roundRepository.GetLastRound(gameId, dealer.Id);
            List<Card> dealerCards = await _cardRepository.GetCards(dealerRound.Id);
            rounds.Remove(dealerRound);

            int dealerScore = CalculateCardScore(dealerCards);
            foreach (var round in rounds)
            {
                Player player = await _playerRepository.GetPlayer(round.Id);
                List<Card> cards = await _cardRepository.GetCards(round.Id);

                int score = CalculateCardScore(cards);
                if (score > dealerScore)
                {
                    round.State = RoundState.Won;
                }
                if (score == dealerScore)
                {
                    round.State = RoundState.Push;
                }
                if (score < dealerScore)
                {
                    round.State = RoundState.Lose;
                }
            }
            _roundRepository.Update(rounds);
        }

        private async Task CreateNextRound(long gameId, int botCount)
        {
            Player user = await _playerRepository.GetPlayer(_userName);
            var rounds = new List<Round> { new Round { GameId = gameId, PlayerId = user.Id } };

            List<Player> bots = await _playerRepository.GetBots(botCount);
            if (bots.Count < botCount)
            {
                List<Player> additionalBots = AddBots(bots.Count, botCount);
                bots.AddRange(additionalBots);
            }
            foreach (var bot in bots)
            {
                var round = new Round { GameId = gameId, PlayerId = bot.Id };
                rounds.Add(round);
            }

            Player dealer = await _playerRepository.GetDealer();
            rounds.Add(new Round { GameId = gameId, PlayerId = dealer.Id });
            _roundRepository.Add(rounds);

            List<long> shuffledCards = CardHelper.GetShuffledCards();

            var roundCards = new List<RoundCard>();
            for (int i = 0; i < rounds.Count; i++)
            {
                roundCards.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i] });
                roundCards.Add(
                    new RoundCard { RoundId = rounds[i].Id, CardId = shuffledCards[i + rounds.Count] });
            }
            _roundCardRepository.Add(roundCards);
            shuffledCards.RemoveRange(0, rounds.Count * 2);

            var gameSession = new GameSession { GameId = gameId, ShuffledCards = shuffledCards };
            _session.Set(_userName, gameSession);
        }



        private static int CalculateCardScore(List<Card> cards)
        {
            int score = 0;
            foreach (var card in cards)
            {
                score += CardHelper.GetCardScore(card.Rank);
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
        #endregion
    }
}
