﻿using System.Collections.Generic;
using AutoMapper;
using BlackJack.BusinessLogic.DTO;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class CardService : BaseService, ICardService
    {
        public CardService(IDbWorker dbWorker) : base(dbWorker)
        {
        }

        public IEnumerable<CardDTO> GetCardList()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Card, CardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Card>, List<CardDTO>>(_dbWorker.Cards.GetAll());
        }
    }
}