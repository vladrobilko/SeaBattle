using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;
using SeaBattleApi.Services;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaBattleSessionController : Controller
    {
        private readonly ISeaBattleGameSessionService _seaBattleGameSessionService;
        public SeaBattleSessionController(ISeaBattleGameSessionService seaBattleGameSessionService)
        {
            _seaBattleGameSessionService = seaBattleGameSessionService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllSessions()
        {
            return Json(_seaBattleGameSessionService.GetAllSessions());
        }

        [HttpPost("[action]")]
        public IActionResult CreateSession([FromBody] string idPlayer, [FromBody] string nameGame)
        {            
            _seaBattleGameSessionService.CreateSession(idPlayer, nameGame);
            return Ok("The session has been created.");
        }

        [HttpPost("[action]")]
        public IActionResult ConnectToSession([FromBody] string idPlayer, [FromBody] string idSession)
        {
            _seaBattleGameSessionService.AddPlayerInSession(idPlayer, idSession);
            return Ok();
        }
    }
}
