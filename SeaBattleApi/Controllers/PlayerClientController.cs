using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeaBattleApi.Models;
using SeaBattleApi.Services;
using SeaBattleApi.Services.Intefaces;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult Login([FromBody][MinLength(3)] string playerName)
        {
            if (playerName != null)
            {
                _playerClientService.Add(playerName);
                return Ok();
            }
            return BadRequest("Something is wrong");
        }

        [HttpPost("[action]")]
        public ActionResult<PlayerClient> GetByName([FromBody] string name)
        {
            if (name != null)
            {
                return Ok(_playerClientService.GetByName(name));
            }
            return BadRequest("Something is wrong");
        }

        [HttpGet("[action]")]
        public ActionResult<List<PlayerClient>> GetAll()
        {
            return Ok(_playerClientService.GetAll());
        }
    }
}
