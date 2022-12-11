using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;

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
        public IActionResult HostSession([FromBody] HostSessionClientModel hostSessionClientModel)
        {
            try
            {
                _session.CreateNewSession(hostSessionClientModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("The session was not started. Error message: " + e.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<HostSessionClientModel>> GetAllWaitingSessions()
        {
            try
            {
                return Ok(_session.
               GetAllNewSessions().
               ConvertToListNewSessionClient());
            }
            catch (Exception e)
            {
                return BadRequest("Sessions were not given. Error message: " + e.Message);
            }

        }

        [HttpPost("[action]")]
        public IActionResult JoinSession([FromBody] JoinSessionClientModel joinToSessionClient)
        {
            try
            {
                _session.JoinToSession(joinToSessionClient);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Couldn't connect to the session. Error message: " + e.Message);
            }
        }
    }
}