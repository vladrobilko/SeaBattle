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
        public ActionResult<string> GetPlayArea([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameClientModel = new GameAreaClientModel();
            gameClientModel.ClientPlayArea = new string[10][];
            var json = JsonConvert.SerializeObject(gameClientModel);
            return Ok(json);
        }

        //возвратить игровую арену в виде массива строк(сверху)
        [HttpPost("[action]")]
        public ActionResult<string[,]> ChangePlayArea([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            string[,] area = new string[10, 10];
            return Ok(area);//возвратить новую игровую арену в виде массива строк 
        }

        [HttpPost("[action]")]
        public ActionResult<string[,]> ReadyToStartGame([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            string[,] area = new string[10, 10];
            return Ok(area);//если можно быть готовым, возвратить ок и модель игрока чтобы показать игровое поле
        }

        [HttpPost("[action]")]
        public ActionResult<GameClientModel> GetGameModel([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            return Ok(new GameClientModel());//если игра началалсь и ход этого игрока вернуть модель (обновленное поле и сообщение для игрока)
        }

        [HttpPost("[action]")]
        public IActionResult Shoot([FromBody] PlayerClientShootModel playerClientShootModel)
        {
            return Ok(new GameClientModel());//вернуть модель игры с сообщением 
        }

        [HttpPost("[action]")]
        public ActionResult<string> EndGame([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            var gameModel = new GameClientModel();
            return Ok(gameModel.Message);//когда кто то проиграл
        }
    }
}
