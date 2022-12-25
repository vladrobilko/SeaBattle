using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;
using System.Xml.Linq;

namespace SeaBattle.Repository.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        List<PlayerSeaBattleStateModel> _lastPlayerModels;//последняя модель игрока, когда игрок выбирает игровую арену,
                                                          //ему посылается игровая арена и записвается сюда (старая удаляется)
        List<PlayerSeaBattleStateModel> _confirmedPlayerModels;//когда игрок выбрал арену, сврху она удаляется и записывается сюда, как текущая модель игрока

        List<GameStateModel> _gameStateModels;//когда два игрока готовы к игре, игра стартуется и сюда сохраняется модель игры
                                              //в эту модель будет сервис будет вносить изменения 
        List<ShootModel> _lastValidShootModel;

        public SeaBattleGameRepositoty()
        {
            _lastPlayerModels = new List<PlayerSeaBattleStateModel>();
            _confirmedPlayerModels = new List<PlayerSeaBattleStateModel>();
            _gameStateModels = new List<GameStateModel>();
            _lastValidShootModel = new List<ShootModel>();
        }

        public void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel)
        {
            _lastPlayerModels.Remove(_lastPlayerModels.SingleOrDefault(p => p?.Name == playerModel.Name));
            _lastPlayerModels.Add(playerModel);
        }

        public void SaveConfirmedPlayerStateModel(string name)
        {
            _confirmedPlayerModels.Add(_lastPlayerModels
                .SingleOrDefault(p => p.Name == name) ?? throw new DirectoryNotFoundException());
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name)
        {
            return _confirmedPlayerModels.SingleOrDefault(p => p.Name == name);
        }

        public void ResaveGameStateModel(GameStateModel gameStateModel)
        {
            _gameStateModels.Remove(_gameStateModels.SingleOrDefault(p => p?.NameSession == gameStateModel.NameSession));
            _gameStateModels.Add(gameStateModel);
        }

        public GameStateModel GetGameStateModelByNameSession(string nameSession)
        {
            return _gameStateModels.SingleOrDefault(p => p?.NameSession == nameSession) ?? throw new NotFiniteNumberException();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            if (GetGameStateModelByNameSession(shootModel.SessionName).NamePlayerTurn == shootModel.PlayerName)
            {
                _lastValidShootModel.Remove(_lastValidShootModel.SingleOrDefault(p => p?.SessionName == shootModel.SessionName));
                _lastValidShootModel.Add(shootModel);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
