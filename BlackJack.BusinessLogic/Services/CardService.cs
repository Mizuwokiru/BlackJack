using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //public IEnumerable<int> GetShuffledCardIds()
        //{
        //    var cards = Enumerable.Range(1, Constants.DeckCapacity).ToList();
        //    var unshuffledCards = new int[Constants.GameCardCount];
        //    for (int i = 0; i < Constants.DeckCount; i++)
        //    {
        //        for (int j = 0; j < Constants.DeckCapacity; j++)
        //        {
        //            unshuffledCards[i * Constants.DeckCapacity + j] = cards[j];
        //        }
        //    }
        //    var cardIndexSequence = Enumerable.Range(0, Constants.GameCardCount).ToList();
        //    var shuffledCards = new List<int>();
        //    var random = new Random();
        //    for (int i = 0; i < Constants.GameCardCount; i++)
        //    {
        //        var randIndex = random.Next(cardIndexSequence.Count);
        //        shuffledCards.Add(unshuffledCards[cardIndexSequence[randIndex]]);
        //        cardIndexSequence.RemoveAt(randIndex);
        //    }

        //    return shuffledCards;
        //}

        public Queue<CardViewModel> GetShuffledCards()
        {
            var cardsFromDb = _cardRepository.GetAll().ToList();
            if (cardsFromDb.Count < Constants.DeckCapacity)
            {
                throw new ValidationException("Cards is not enough.");
            }

            var unshuffledCards = new List<CardViewModel>();
            foreach (var cardFromDb in cardsFromDb)
            {
                var card = new CardViewModel { Rank = cardFromDb.Rank.ToString(), Suit = cardFromDb.Suit.ToString() };
                for (int i = 0; i < Constants.DeckCount; i++)
                {
                    unshuffledCards.Add(card);
                }
            }

            var cardIndexSequence = Enumerable.Range(0, Constants.GameCardCount).ToList();
            var random = new Random();
            var shuffledCards = new Queue<CardViewModel>();
            for (int i = 0; i < Constants.GameCardCount; i++)
            {
                var randIndex = random.Next(cardIndexSequence.Count);
                shuffledCards.Enqueue(unshuffledCards[cardIndexSequence[randIndex]]);
                cardIndexSequence.RemoveAt(randIndex);
            }

            return shuffledCards;
        }
    }
}
