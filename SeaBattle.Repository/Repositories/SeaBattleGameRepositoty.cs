using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Converters;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Repository.Repositories
{
    /*public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly List<PlayerSeaBattleStateModel> _playerModels;

        private readonly List<GameStateDtoModel> _gameStateModels;

        private readonly List<ShootModel> _lastValidShootModel;

        public SeaBattleGameRepositoty()
        {
            _playerModels = new List<PlayerSeaBattleStateModel>();
            _gameStateModels = new List<GameStateDtoModel>();
            _lastValidShootModel = new List<ShootModel>();
        }

        public void SavePlayerStateModelOrResaveToChangePlayArea(PlayerSeaBattleStateModel playerModel)
        {
            _playerModels.Remove(_playerModels.SingleOrDefault(p => p?.NamePlayer == playerModel.NamePlayer));

            _playerModels.Add(playerModel);
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name)
        {
            return _playerModels.SingleOrDefault(p => p.NamePlayer == name);
        }

        public void ResaveGameStateDtoModel(GameState gameStateModel, string nameSession)
        {
            _gameStateModels.Remove(_gameStateModels.SingleOrDefault(p => p?.NameSession == nameSession));

            _gameStateModels.Add(gameStateModel.ConvertToGameStateDtoModel(nameSession));
        }

        public GameState GetGameStateModelByNameSession(string nameSession)
        {
            var gameStateModel = _gameStateModels.SingleOrDefault(p => p?.NameSession == nameSession);

            if (gameStateModel != null)
            {
                return gameStateModel.ConvertToGameStateModel();
            }

            throw new NotFiniteNumberException();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            if (GetGameStateModelByNameSession(shootModel.NameSession).NamePlayerTurn == shootModel.NamePlayer)
            {
                _lastValidShootModel.Remove(_lastValidShootModel.SingleOrDefault(p => p?.NameSession == shootModel.NameSession));

                _lastValidShootModel.Add(shootModel);
            }

            else
            {
                throw new NotSupportedException();
            }
        }

        public ShootModel GetLastShootModelOrNullByName(string namePlayer)
        {
            return _lastValidShootModel.SingleOrDefault(p => p?.NamePlayer == namePlayer);
        }
    }*/
}
