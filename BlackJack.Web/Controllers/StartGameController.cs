﻿using AutoMapper;
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
            var list = new List<PlayerDTO>(_playerService.GetPlayableList());
            list.AddRange(_playerService.GetBotList());
            var players = mapper.Map<IEnumerable<PlayerDTO>, List<Player>>(list);
            
            return View(players);
        }
    }
}