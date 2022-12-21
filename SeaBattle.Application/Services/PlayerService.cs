using SeaBattle.Api.Controllers;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using System.Data;

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
            if (_playerRepository.IsPlayerRegistered(name))
                throw new DuplicateNameException();
            _playerRepository.SaveNewPlayerOrThrowExeption(name);
        }
    }
}