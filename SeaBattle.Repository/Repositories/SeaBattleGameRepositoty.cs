using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;
using System.Xml.Linq;

namespace SeaBattle.Repository.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        List<PlayerModel> _lastPlayers;

        List<PlayerModel> _confirmedPlayers;

        public SeaBattleGameRepositoty()
        {
            _lastPlayers = new List<PlayerModel>();
            _confirmedPlayers = new List<PlayerModel>();
        }

        public void SaveLastPlayerModel(PlayerModel playerModel)
        {
            var model = _lastPlayers?.SingleOrDefault(p => p.Name == playerModel.Name);
            if (model != null)
            {
                _lastPlayers.Remove(model);
            }
            _lastPlayers.Add(playerModel);
        }

        public void SaveConfirmedPlayerModel(string name)
        {
            _confirmedPlayers.Add(_lastPlayers
                .SingleOrDefault(p => p.Name == name) ?? throw new DirectoryNotFoundException());
        }

        public PlayerModel GetConfirmedPlayerModelByName(string name)
        {
            return _lastPlayers.SingleOrDefault(p => p.Name == name);
        }
    }
}
