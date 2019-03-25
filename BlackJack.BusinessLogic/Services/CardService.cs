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

        public IEnumerable<CardModel> GetShuffledCards()
        {
            IEnumerable<Card> cardsFromDb = _cardRepository.GetAll();

            var deck = new List<CardModel>();
            foreach (var cardFromDb in cardsFromDb)
            {
                deck.Add(new CardModel { Id = cardFromDb.Id, Rank = cardFromDb.Rank, Suit = cardFromDb.Suit });
            }

            var shuffledCards = new List<CardModel>();
            for (int i = 0; i < Constants.DeckCount; i++)
            {
                shuffledCards.AddRange(GetShuffledDeck(deck));
            }

            return shuffledCards;
        }

        private static IEnumerable<CardModel> GetShuffledDeck(List<CardModel> unshuffledDeck)
        {
            var shuffledDeck = new List<CardModel>();
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
    }
}
