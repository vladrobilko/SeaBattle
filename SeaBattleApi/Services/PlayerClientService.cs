using SeaBattle;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class PlayerClientService : IPlayerClientService
    {
        private static List<IPlayerClient> _players;

        public PlayerClientService()
        {
            _players = new List<IPlayerClient>();
        }

        public void Add(string name)
        {
            var player = new PlayerClient() { Name = name };
            _players.Add(player);
        }

        public IPlayerClient GetById(string id)
        {
            return _players.SingleOrDefault(p => p.ID == id);
        }

        public static IPlayerClient GetByIdOrName(string id = null, string name = null)
        {
            if (name == null)
                return _players.SingleOrDefault(p => p.ID == id);
            return _players.SingleOrDefault(p => p.Name == name);
        }

        public List<IPlayerClient> GetAll()
        {
            return _players;
        }

    }
}
