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
        private readonly ISeaBattleGameService _seaBattleService;

        private readonly IPlayerClientService _player;

        public SeaBattleGameController(ISeaBattleGameService seaBattleService, IPlayerClientService player)
        {              
            _seaBattleService = seaBattleService;
            _player = player;
        }

        [HttpGet("[action]")]
        public IActionResult GameName()
        {
            return Json(_seaBattleService.GetName());
        }

        [HttpGet("[action]")]
        public IActionResult GetPlayerInfo()
        {
            if (_player != null)
            {
                return Json(_player);
            }
            return BadRequest("Something is wrong");
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] PlayerClientService player)
        {
            if (_player.Name == null)//тут по сути и сетаю игрока и гет делать два метода???
            {
                _player.Name = player.Name;
                return Ok();
            }
            return BadRequest("Something is wrong");
        }
    }
}
