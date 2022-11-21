using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.infrastructure.Interfaces;
using SeaBattleApi.Models;
using SeaBattleApi.Services;
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
        public ActionResult<PlayerModel> GetByName([FromBody][Required] string name)//наверное не тут?
        {
            return Ok(_playerClientService.Get(name));
        }

        [HttpGet("[action]")]
        public ActionResult<List<PlayerModel>> GetAll()
        {
            return Ok(_playerClientService.GetAll());
        }
    }
}
