using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<bool> CanContinue(long playerId)
        {
            bool hasUnfinishedGames = _gameService.HasUnfinishedGames(playerId);
            return Ok(hasUnfinishedGames);
        }

        [HttpGet]
        public ActionResult<GameViewModel> NewGame(long playerId, int botCount)
        {
            try
            {
                GameViewModel gameViewModel = _gameService.CreateGame(playerId, botCount);
                return Ok(gameViewModel);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<GameViewModel> Continue(long playerId)
        {
            try
            {
                GameViewModel gameViewModel = _gameService.ContinueGame(playerId);
                return Ok(gameViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerCardsViewModel>> GetRound(long gameId)
        {
            IEnumerable<PlayerCardsViewModel> playerCardsViewModels =
                _gameService.GetRound(gameId);
            return Ok(playerCardsViewModels.ToList());
        }
    }
}