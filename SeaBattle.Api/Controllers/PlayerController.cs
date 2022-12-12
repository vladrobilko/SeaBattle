using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody][MinLength(3)][Required] string playerName)
        {
            try
            {
                _playerService.CreateNewPlayer(playerName);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Failed to register a player. Error message: " + e.Message);
            }
        }
    }
}
