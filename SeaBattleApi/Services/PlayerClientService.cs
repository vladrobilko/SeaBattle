using SeaBattle;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class PlayerClientService : IPlayerClientService
    {
        private static List<PlayerClient> _players;

        public PlayerClientService()
        {
            _players = new List<PlayerClient>();
        }

        public void Add(string name)
        {
            var player = new PlayerClient() { Name = name };
            _players.Add(player);
        }

        public PlayerClient GetById(string id)
        {
            return _players.SingleOrDefault(p => p.ID == id);
        }

        public PlayerClient GetByName(string name)
        {
            return _players.SingleOrDefault(p => p.Name == name);
        }

        public static PlayerClient GetByIdOrName(string id = null, string name = null)
        {
            if (name == null)
                return (PlayerClient)_players.SingleOrDefault(p => p.ID == id);
            return (PlayerClient)_players.SingleOrDefault(p => p.Name == name);
        }

        public List<PlayerClient> GetAll()
        {
            return _players;
        }

    }
}
