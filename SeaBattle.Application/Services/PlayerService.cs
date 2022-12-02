using SeaBattle.Api.Controllers;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

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