﻿using SeaBattle.Application.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel);

        void SaveConfirmedPlayerStateModel(string name);

        PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name);

        void ResaveGameStateDtoModel(GameStateModel gameStateModel, string NameSession);

        GameStateModel GetGameStateModelByNameSessionOrThrowException(string nameSession);

        void ResaveValidShoot(ShootModel shootModel);

        ShootModel GetLastShootModelOrNullByName(string namePlayer);
    }
}