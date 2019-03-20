using AutoMapper;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Models;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private const int DeckCount = 6;

        private ICardRepository _cardRepository;

        public GameService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public IEnumerable<CardModel> GetShuffledCards()
        {
            List<CardModel> deck = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardModel>())
                .CreateMapper()
                .Map<IEnumerable<Card>, List<CardModel>>(_cardRepository.GetAll());

            // TODO: тут убедиться, что количество карт в колоде - 52

            var shuffledCards = new List<CardModel>();
            for (int i = 0; i < DeckCount; i++)
            {
                shuffledCards.AddRange(deck);
            }

            return shuffledCards;
        }
    }
}
