using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels.Models;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> StartGame([FromBody] NewSessionClientModel sessionClientModel)
        {
            try
            {
                await _seaBattleGameService.StartGame(sessionClientModel.SessionName,sessionClientModel.HostPlayerName);
                return Ok("The game has started");
            }
            catch (Exception e)
            {
                return BadRequest("The game was not started. Error message: " + e.Message);
            }
        }

        //тут отослать модель игры и сообзение с тем кто ходит
    }
}
