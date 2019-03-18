using AutoMapper;
using BlackJack.BusinessLogic.DTO;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.Web.Controllers
{
    public class StartGameController : Controller
    {
        ICardService cardService;

        public StartGameController(ICardService service)
        {
            cardService = service;
        }

        public IActionResult Index()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<CardDTO, Card>()).CreateMapper();
            var cards = mapper.Map<IEnumerable<CardDTO>, List<Card>>(cardService.GetCardList());

            return View(cards);
        }
    }
}
