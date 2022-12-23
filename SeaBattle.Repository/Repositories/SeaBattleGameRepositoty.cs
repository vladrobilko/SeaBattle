using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;
using System.Xml.Linq;

namespace SeaBattle.Repository.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        List<PlayerSeaBattleStateModel> _lastPlayers;

        List<PlayerSeaBattleStateModel> _confirmedPlayers;

        List<GameStateModel> _gameStateModels;

        public SeaBattleGameRepositoty()
        {
            _lastPlayers = new List<PlayerSeaBattleStateModel>();
            _confirmedPlayers = new List<PlayerSeaBattleStateModel>();
            _gameStateModels= new List<GameStateModel>();
        }

        public void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel)
        {
            var model = _lastPlayers.SingleOrDefault(p => p?.Name == playerModel.Name);
            if (model != null)
            {
                _lastPlayers.Remove(model);
            }
            _lastPlayers.Add(playerModel);
        }

        public void SaveConfirmedPlayerStateModel(string name)
        {
            _confirmedPlayers.Add(_lastPlayers
                .SingleOrDefault(p => p.Name == name) ?? throw new DirectoryNotFoundException());
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name)
        {
            return _lastPlayers.SingleOrDefault(p => p.Name == name);
        }

        public void ResaveGameStateModel(GameStateModel gameStateDtoModel)
        {
            var model = _gameStateModels.SingleOrDefault(p => p?.NameSession == gameStateDtoModel.NameSession);
            if (model != null)
            {
                _gameStateModels.Remove(model);
            }
            _gameStateModels.Add(gameStateDtoModel);
        }

        public GameStateModel GetGameStateModelByNameSession(string nameSession)
        {
            return _gameStateModels.SingleOrDefault(p => p?.NameSession == nameSession) ?? throw new NotFiniteNumberException();
        }
    }
}
