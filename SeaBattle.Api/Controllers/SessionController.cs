using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                return BadRequest("Server error: " + e.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<HostSessionClientModel>> GetAllWaitingSessions()
        {
            try
            {
                var json = JsonConvert
                    .SerializeObject(_session
                    .GetAllNewSessions()
                    .ConvertToListHostSessionClientModel());
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest("Server error: " + e.Message);
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
                return BadRequest("Server error: " + e.Message);
            }
        }
    }
}