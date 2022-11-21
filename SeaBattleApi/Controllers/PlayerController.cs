using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattleApi.Services.Intefaces;
using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerModelService _playerClientService;

        public PlayerController(IPlayerModelService playerClientService)
        {
            _playerClientService = playerClientService;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody][MinLength(3)][Required] string playerName)
        {
            _playerClientService.Create(playerName);
            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult<PlayerClient> GetByName([FromBody][Required] string name)
        {
            return Ok(_playerClientService.Get(name).ConvertToPlayerClient());
        }
    }
}
