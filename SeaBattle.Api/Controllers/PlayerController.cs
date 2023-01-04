using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels.Models;

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
        public IActionResult Register([FromBody] PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            _playerService.CreateNewPlayer(playerRegistrationClientModel);
            return Ok();
        }
    }
}
