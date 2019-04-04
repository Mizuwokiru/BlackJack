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
        public ActionResult<GameViewModel> New(long playerId, int botCount)
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

        [HttpGet("{gameId}")]
        public ActionResult<PlayersCardsViewModel> GetRound(long gameId)
        {
            PlayersCardsViewModel playersCardsViewModel =
                _gameService.GetRound(gameId);
            return Ok(playersCardsViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult<GetCardViewModel> GetCard(long gameId)
        {
            try
            {
                GetCardViewModel getCardViewModel = _gameService.GetCard(gameId);
                return Ok(getCardViewModel);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{gameId}")]
        public ActionResult<GetResultsViewModel> GetResults(long gameId)
        {
            GetResultsViewModel getResultsViewModel = _gameService.GetResults(gameId);
            return Ok(getResultsViewModel);
        }
    }
}