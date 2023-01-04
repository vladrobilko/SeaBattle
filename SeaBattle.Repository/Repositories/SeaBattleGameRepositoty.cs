using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Converters;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Repository.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly List<PlayerSeaBattleStateModel> _lastPlayerModels;//последняя модель игрока, когда игрок выбирает игровую арену,
                                                                           //ему посылается игровая арена и записвается сюда (старая удаляется)
        private readonly List<PlayerSeaBattleStateModel> _confirmedPlayerModels;//когда игрок выбрал арену, сврху она удаляется и записывается сюда, как текущая модель игрока

        private readonly List<GameStateDtoModel> _gameStateModels;//когда два игрока готовы к игре, игра стартуется и сюда сохраняется модель игры
                                                                  //в эту модель будет сервис будет вносить изменения 
        private readonly List<ShootModel> _lastValidShootModel;

        public SeaBattleGameRepositoty()
        {
            _lastPlayerModels = new List<PlayerSeaBattleStateModel>();
            _confirmedPlayerModels = new List<PlayerSeaBattleStateModel>();
            _gameStateModels = new List<GameStateDtoModel>();
            _lastValidShootModel = new List<ShootModel>();
        }

        public void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel)
        {
            _lastPlayerModels.Remove(_lastPlayerModels.SingleOrDefault(p => p?.NamePlayer == playerModel.NamePlayer));
            _lastPlayerModels.Add(playerModel);
        }

        public void SaveConfirmedPlayerStateModel(string name)
        {
            _confirmedPlayerModels.Add(_lastPlayerModels
                .SingleOrDefault(p => p.NamePlayer == name) ?? throw new DirectoryNotFoundException());
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name)
        {
            return _confirmedPlayerModels.SingleOrDefault(p => p.NamePlayer == name);
        }

        public void ResaveGameStateDtoModel(GameState gameStateModel, string nameSession)
        {
            _gameStateModels.Remove(_gameStateModels.SingleOrDefault(p => p?.NameSession == nameSession));
            _gameStateModels.Add(gameStateModel.ConvertToGameStateDtoModel(nameSession));
        }

        public GameState GetGameStateModelByNameSessionOrThrowException(string nameSession)
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
            if (GetGameStateModelByNameSessionOrThrowException(shootModel.NameSession).NamePlayerTurn == shootModel.NamePlayer)
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
    }
}
