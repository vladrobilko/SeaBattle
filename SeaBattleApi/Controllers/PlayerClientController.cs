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
        public IActionResult Login([FromBody][MinLength(3)][Required] string playerName)
        {
            _playerClientService.Add(playerName);
            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult<PlayerClientModel> GetByName([FromBody][Required] string name)
        {
            return Ok(_playerClientService.GetByName(name));
        }

        [HttpGet("[action]")]
        public ActionResult<List<PlayerClientModel>> GetAll()
        {
            return Ok(_playerClientService.GetAll());
        }
    }
}
