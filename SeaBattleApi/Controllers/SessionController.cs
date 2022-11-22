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
        public IActionResult Register([FromBody][MinLength(3)][Required] string playerName)
        {
            _session.CreateNewPlayer(playerName);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult NewSession([FromBody] NewSessionClient newSessionClient)
        {
            _session.CreateNewSession(newSessionClient);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetAllSessions()
        {
            return Ok(_session.GetAllNewSessions().ConvertToListNewSessionClient());
        }

        //[HttpPost("[action]")]
        //pubic IActionResult Join
    }
}