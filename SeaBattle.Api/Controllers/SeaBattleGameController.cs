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
        public ActionResult<GameAreaClientModel> GetPlayArea([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameClientModel = new GameAreaClientModel() { ClientPlayArea = new string[10][] };
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameAreaClientModel> ChangePlayArea([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameClientModel = new GameAreaClientModel() { ClientPlayArea = new string[10][] };
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> ReadyToStartGame([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameClientModel = new GameClientModel();
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> GetGameModel([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameClientModel = new GameClientModel();
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }

        [HttpPost("[action]")]//last
        public ActionResult<GameClientModel> Shoot([FromBody] PlayerClientShootModel playerClientShootModel)
        {
            var gameClientModel = new GameClientModel();
            return Ok(JsonConvert.SerializeObject(gameClientModel));
        }
    }
}
