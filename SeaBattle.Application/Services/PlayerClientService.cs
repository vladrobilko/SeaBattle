using SeaBattle;
using SeaBattleApi.Models;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class PlayerClientService : IPlayerClientService
    {
        private static List<PlayerClientModel> _players;

        public PlayerClientService()
        {
            _players = new List<PlayerClientModel>();
        }

        public void Add(string name)
        {
            var player = new PlayerClientModel() { Name = name };
            _players.Add(player);
        }

        public PlayerClientModel GetByName(string name)
        {
            return _players.SingleOrDefault(p => p.Name == name);
        }

        public List<PlayerClientModel> GetAll()
        {
            return _players;
        }
    }
}
