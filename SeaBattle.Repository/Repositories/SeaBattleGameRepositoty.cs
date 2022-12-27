﻿using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Converters;
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

        List<GameStateDtoModel> _gameStateModels;//когда два игрока готовы к игре, игра стартуется и сюда сохраняется модель игры
                                              //в эту модель будет сервис будет вносить изменения 
        List<ShootModel> _lastValidShootModel;

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

        public void ResaveGameStateDtoModel(GameStateModel gameStateModel, string NameSession)
        {
            _gameStateModels.Remove(_gameStateModels.SingleOrDefault(p => p?.NameSession == NameSession));
            _gameStateModels.Add(gameStateModel.ConvertToGameStateDtoModel(NameSession));
        }

        public GameStateModel GetGameStateModelOrThrowExceptionByNameSession(string nameSession)
        {
            return _gameStateModels.SingleOrDefault(p => p.NameSession == nameSession)//тут что то null
                .ConvertToGameStateModel() ?? throw new NotFiniteNumberException();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            if (GetGameStateModelOrThrowExceptionByNameSession(shootModel.NameSession).NamePlayerTurn == shootModel.NamePlayer)
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
