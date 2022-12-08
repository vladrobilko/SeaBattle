﻿using Microsoft.AspNetCore.Mvc;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Services.Interfaces;

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
        public IActionResult StartGameHostPlayer([FromBody] HostSessionClientModel sessionClientModel)
        {
            try
            {
                _seaBattleGameService.StartGame(sessionClientModel.SessionName,sessionClientModel.HostPlayerName);
                return Ok("The game has started");//тут отослать модель игры и сообзение с тем кто ходит
            }
            catch (Exception e)
            {
                return BadRequest("The game was not started. Error message: " + e.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult GetPlayArea([FromBody] string name)
        {
            return Ok();//возвратить игровую арену с массивом 
        }

        [HttpPost("[action]")]
        public IActionResult StartGameJoinPlayer([FromBody] JoinSessionClientModel sessionClientModel)
        {
            return Ok();//стать готовым 
        }
    }
}
