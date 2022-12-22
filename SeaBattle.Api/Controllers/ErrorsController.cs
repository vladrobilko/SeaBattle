using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SeaBattle.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ErrorsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("/error")]
        public IActionResult Index()
        {
            Exception? exception = _httpContextAccessor.HttpContext?.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message, statusCode: 400);
        }
    }
}
