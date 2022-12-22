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
            _session.CreateNewSession(hostSessionClientModel);
            return Ok();
        }

        [HttpGet("[action]")]
        public ActionResult<List<HostSessionClientModel>> GetAllWaitingSessions()
        {
            var json = JsonConvert
                .SerializeObject(_session
                .GetAllNewSessions());
            return Ok(json);
        }

        [HttpPost("[action]")]
        public IActionResult JoinSession([FromBody] JoinSessionClientModel joinToSessionClient)
        {
            _session.JoinToSession(joinToSessionClient);
            return Ok();
        }
    }
}