using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using System.Data;

namespace SeaBattle.Repository.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<PlayerRegistrationDtoModel> _registeredPlayers;

        public PlayerRepository()
        {
            _registeredPlayers = new List<PlayerRegistrationDtoModel>();
        }

        public void SaveNewPlayer(PlayerRegistrationModel playerRegistrationModel)
        {
            if (IsPlayerRegistered(playerRegistrationModel.NamePlayer))
                throw new DuplicateNameException();
            var player = new PlayerRegistrationDtoModel() { Name = playerRegistrationModel.NamePlayer };
            _registeredPlayers.Add(player);
        }

        public bool IsPlayerRegistered(string name)
        {
            return _registeredPlayers.SingleOrDefault(p => p.Name == name) != null;
        }
    }
}