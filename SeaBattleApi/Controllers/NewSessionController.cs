using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;

namespace SeaBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewSessionController : Controller
    {
        private readonly INewSessionModelService _modelService;

        public NewSessionController(INewSessionModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("[action]")]
        public IActionResult NewSession([FromBody] NewSessionClient newSessionClient)
        {
            _modelService.NewSession(newSessionClient);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetSession([FromBody] string sessionName)
        {
            return Ok(_modelService.GetSession(sessionName).ConvertToNewSessionClient());
        }

        [HttpGet("[action]")]
        public IActionResult GetAllSessions()
        {
            return Ok(_modelService.GetAll().ConvertToListNewSessionClient());
        }
    }
}
