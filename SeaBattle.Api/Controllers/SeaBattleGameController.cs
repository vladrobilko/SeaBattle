using Microsoft.AspNetCore.Mvc;
using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("[action]")]
        public IActionResult StartGame()
        {
            _seaBattleGameService.StartGame();
            return Ok();
        }
    }
}
