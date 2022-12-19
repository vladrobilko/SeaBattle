using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace SeaBattle.Repository.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<PlayerDtoModel> _registeredPlayers;

        public PlayerRepository()
        {
            _registeredPlayers = new List<PlayerDtoModel>();
        }

        public void AddNewPlayerOrThrowExeption(string name)
        {
            var player = new PlayerDtoModel() { Name = name };
            _registeredPlayers.Add(player);
        }

        public bool IsPlayerRegistered(string name)
        {
            return _registeredPlayers.SingleOrDefault(p => p.Name == name) != null;
        }
    }
}