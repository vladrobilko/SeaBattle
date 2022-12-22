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
        public ActionResult<GameClientModel> GetGameModel([FromBody] InfoPlayerClientModel infoPlayerClientModel)
        {
            string[][] arr = new string[10][];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new string[10] { "*", "*", "*", "#", "*", "*", "*", "*", "*", "*" };
            }

            string[][] arr1 = new string[10][];
            for (int i = 0; i < 10; i++)
            {
                arr1[i] = new string[10] { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            }

            var gameClientModel = new GameClientModel();
            gameClientModel.ClientPlayArea = arr;
            gameClientModel.EnemyPlayArea = arr1;
            gameClientModel.IsPlayerTurnToShoot = true;
            gameClientModel.IsGameOn = true;
            gameClientModel.Message = "Your turn to shoot";

            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> Shoot([FromBody] ShootPlayerClientModel shootPlayerClientModel)
        {
            var gameClientModel = new GameClientModel();
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }
    }
}