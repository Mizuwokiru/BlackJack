using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogic.Models;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared;

namespace BlackJack.BusinessLogic.Services
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public IEnumerable<CardViewModel> GetShuffledCards()
        {
            IEnumerable<Card> cardsFromDb = _cardRepository.GetAll();

            var deck = new List<CardViewModel>();
            foreach (var cardFromDb in cardsFromDb)
            {
                deck.Add(new CardViewModel { Id = cardFromDb.Id, Rank = cardFromDb.Rank, Suit = cardFromDb.Suit });
            }

            var shuffledCards = new List<CardViewModel>();
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                shuffledCards.AddRange(GetShuffledDeck(deck));
            }

            return shuffledCards;
        }

        private static IEnumerable<CardViewModel> GetShuffledDeck(List<CardViewModel> unshuffledDeck)
        {
            var shuffledDeck = new List<CardViewModel>();
            var cardIndexSequence = Enumerable.Range(0, unshuffledDeck.Count).ToList();
            var random = new Random();
            for (int i = 0; i < unshuffledDeck.Count; i++)
            {
                var randIndex = random.Next(cardIndexSequence.Count);
                shuffledDeck.Add(unshuffledDeck[cardIndexSequence[randIndex]]);
                cardIndexSequence.RemoveAt(randIndex);
            }
            return shuffledDeck;
        }

        public IEnumerable<int> GetShuffledCardIds()
        {
            var cards = Enumerable.Range(1, Constants.DeckCapacity).ToList();
            var unshuffledCards = new int[Constants.GameCardCount];
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                for (int j = 0; j < Constants.DeckCapacity; j++)
                {
                    unshuffledCards[i * Constants.DeckCapacity + j] = cards[j];
                }
            }
            var cardIndexSequence = Enumerable.Range(0, Constants.GameCardCount).ToList();
            var shuffledCards = new List<int>();
            var random = new Random();
            for (int i = 0; i < Constants.GameCardCount; i++)
            {
                var randIndex = random.Next(cardIndexSequence.Count);
                shuffledCards.Add(unshuffledCards[randIndex]);
                cardIndexSequence.RemoveAt(randIndex);
            }

            return shuffledCards;
        }
    }
}
