using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Services.Interfaces;
using System;

namespace SeaBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaBattleGameController : Controller
    {
        private readonly ISeaBattleGameService _seaBattleGameService;

        public SeaBattleGameController(ISeaBattleGameService seaBattleGameService)
        {
            _seaBattleGameService = seaBattleGameService;
        }

        [HttpPost("[action]")]
        public ActionResult<GameAreaClientModel> GetPlayArea([FromBody] InfoPlayerClientModel infoPlayerClientModel)
        {
            var gameClientModel = _seaBattleGameService.GetPlayArea(infoPlayerClientModel);
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public IActionResult ReadyToStartGame([FromBody] InfoPlayerClientModel infoPlayerClientModel)
        {
            _seaBattleGameService.ReadyToStartGame(infoPlayerClientModel);
            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientStateModel> GetGameModel([FromBody] InfoPlayerClientModel infoPlayerClientModel)
        {
            var gameClientModel = _seaBattleGameService.GetGameModel(infoPlayerClientModel);
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult Shoot([FromBody] ShootClientModel shootPlayerClientModel)
        {
            _seaBattleGameService.Shoot(shootPlayerClientModel);
            return Ok();
        }
    }
}