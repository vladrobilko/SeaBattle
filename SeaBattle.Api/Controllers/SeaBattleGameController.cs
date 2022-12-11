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
            return Ok();//возвратить новую игровую арену в виде массива строк 
        }

        [HttpPost("[action]")]
        public IActionResult ReadyToStartGame([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            return Ok();//если можно быть готовым, возвратить ок и модель игрока чтобы показать игровое поле
        }

        [HttpPost("[action]")]
        public IActionResult GetGameModel([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            return Ok();//если игра началалсь и ход этого игрока вернуть модель (обновленное поле и сообщение для игрока)
        }

        [HttpPost("[action]")]
        public IActionResult Shoot([FromBody] PlayerClientShootModel playerClientShootModel)
        {
            return Ok();//вернуть модель игры с сообщением 
        }

        [HttpPost("[action]")]
        public IActionResult EndGame([FromBody] PlayerClientInfoModel playerClientInfoModel)
        {
            return Ok();//когда кто то проиграл
        }
    }
}
