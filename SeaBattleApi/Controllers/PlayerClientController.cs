using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeaBattleApi.Models;
using SeaBattleApi.Services;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerClientController : Controller
    {
        private readonly IPlayerClientService _playerClientService;

        public PlayerClientController(IPlayerClientService playerClientService)
        {
            _playerClientService = playerClientService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] string playerName)
        {
            if (playerName != null)
            {
                _playerClientService.Add(playerName);
            }
            return BadRequest("Something is wrong");
        }

        [HttpGet("[action]")]
        public IActionResult GetPlayer([FromBody] string id)
        {
            if (id != null)
            {
                return Json(_playerClientService.GetById(id));
            }
            return BadRequest("Something is wrong");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllPlayers()
        {
            return Json(_playerClientService.GetAll());
        }
    }
}
