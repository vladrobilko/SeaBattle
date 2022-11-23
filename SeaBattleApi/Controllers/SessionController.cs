using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;
using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly ISessionService _session;

        public SessionController(ISessionService modelService)
        {
            _session = modelService;
        }

        [HttpPost("[action]")]
        public IActionResult RegisterNewPlayer([FromBody][MinLength(3)][Required] string playerName)
        {
            _session.CreateNewPlayer(playerName);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult StartNewSession([FromBody] NewSessionClientModel newSessionClient)
        {
            _session.CreateNewSession(newSessionClient);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetAllWaitingSessions()
        {
            return Ok(_session.GetAllNewSessions().ConvertToListNewSessionClient());
        }

        [HttpPost("[action]")]
        public IActionResult JoinToSession([FromBody] JoinToSessionClientModel joinToSessionClient)
        {
            if (_session.IsJoinToSession(joinToSessionClient))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}