using SeaBattle.Api.Controllers;
using SeaBattle.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void CreateNewPlayer(string name)
        {
            _playerRepository.AddNewPlayerOrThrowExeption(name);
        }
    }
}