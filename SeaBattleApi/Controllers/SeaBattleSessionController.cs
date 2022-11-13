﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAll()
        {
            return Json(_seaBattleGameSessionService.GetAllSessions());
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] SeaBattleGameSession seaBattleGameSession)
        {
            if (seaBattleGameSession != null)
            {
                _seaBattleGameSessionService.CreateSession(seaBattleGameSession);
                return Ok("The session has been created.");
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Connect([FromBody] string idPlayer)
        {
            _seaBattleGameSessionService.AddPlayerInSession(idPlayer);
            return Ok();
        }
    }
}
