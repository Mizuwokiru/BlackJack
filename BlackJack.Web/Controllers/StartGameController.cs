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
        private IPlayerService _playerService;

        public StartGameController(IPlayerService service)
        {
            _playerService = service;
        }

        public IActionResult Index()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<PlayerDTO, Player>()).CreateMapper();
            var playerList = new List<PlayerDTO>(_playerService.GetPlayableList());
            playerList.AddRange(_playerService.GetBotList());
            
            return View(mapper.Map<IEnumerable<PlayerDTO>, List<Player>>(playerList));
        }
    }
}
