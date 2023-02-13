using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Interfaces;
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

        public void CreatePlayer(PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            _playerRepository.Create(playerRegistrationClientModel.ToPlayerRegistrationModel());
        }
    }
}