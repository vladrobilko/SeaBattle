using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeaBattleApi.Services;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaBattleGameController : Controller
    {
        ISeaBattleGameService _seaBattleService;

        public SeaBattleGameController(ISeaBattleGameService seaBattleService)
        {
            _seaBattleService = seaBattleService;
        }

        [HttpGet("[action]")]
        public IActionResult GameName()
        {
            return Json(_seaBattleService.GetGameName());
        }

        [HttpPost("[action]")]
        public IActionResult SetPlayerName([FromBody] PlayerClient player)
        {
            PlayerClient player1 = new PlayerClient();
            player1.Name = player.Name;
            if (player1.Name == null || player.Name == null)
            {
                return NotFound("Player don't recorded");
            }
            return Ok($"{player1.Name} is in the game");
        }
    }
}
