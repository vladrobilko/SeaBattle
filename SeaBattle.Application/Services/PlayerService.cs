using SeaBattle.Api.Controllers;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
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

        public void CreateNewPlayer(PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            _playerRepository.SaveNewPlayer(playerRegistrationClientModel.ConvertToPlayerRegistrationModel());
        }
    }
}