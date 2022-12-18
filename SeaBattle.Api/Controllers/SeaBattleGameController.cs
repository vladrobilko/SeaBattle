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
        //может начать использование паттерна поведение с игры, так как уже написано до сессии
        //а игру начать писать с методикой tdd. сначала тест потом код

        [HttpPost("[action]")]
        public ActionResult<GameAreaClientModel> GetPlayArea([FromBody] InfoPlayerClientModel playerClientInfoModel)
        {
            string[][] arr = new string[10][];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new string[10] { "*", "*", "*", "#", "*", "*", "*", "*", "*", "*" };
            }
            var gameClientModel = new GameAreaClientModel() { ClientPlayArea = arr };
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameAreaClientModel> ChangePlayArea([FromBody] InfoPlayerClientModel playerClientInfoModel)
        {
            var gameClientModel = new GameAreaClientModel() { ClientPlayArea = new string[10][] };
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> ReadyToStartGame([FromBody] InfoPlayerClientModel playerClientInfoModel)
        {
            return Ok("You are ready to play, wait for the enemy.");
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> GetGameModel([FromBody] InfoPlayerClientModel playerClientInfoModel)
        {
            string[][] arr = new string[10][];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new string[10] { "*", "*", "*", "#", "*", "*", "*", "*", "*", "*" };
            }
            var gameClientModel = new GameClientModel();
            gameClientModel.ClientPlayArea = arr;
            gameClientModel.IsGameStarted = true;
            gameClientModel.Message = "The game is starting";
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]//last
        public ActionResult<GameClientModel> Shoot([FromBody] InfoPlayerClientModel playerClientShootModel)
        {
            var gameClientModel = new GameClientModel();
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }
    }
}