using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Services.Interfaces;

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
        public ActionResult<string[,]> GetPlayArea([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            string[,] area = new string[10, 10];
            return Ok(area);//возвратить игровую арену в виде массива строк
        }

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
