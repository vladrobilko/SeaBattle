﻿using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;

namespace SeaBattle.Repository.Converters
{
    public static class GameStateModelConverter
    {
        public static GameClientStateModel ConvertToGameClientModel(this GameState gameStateModel, string nameClient)
        {
            var gameClientModel = new GameClientStateModel()
            {
                IsGameOn = gameStateModel.IsGameOn,
                NamePlayerTurn = gameStateModel.NamePlayerTurn,
                Message = gameStateModel.GameMessage
            };

            if (gameStateModel.Player1.NamePlayer == nameClient)
            {
                gameClientModel.ClientPlayArea = gameStateModel.Player1.GetPlayArea().ToStringsForClient();
                gameClientModel.EnemyPlayArea = gameStateModel.Player2.GetPlayArea().ToStringsForClientEnemyPlayArea();
            }

            else
            {
                gameClientModel.ClientPlayArea = gameStateModel.Player2.GetPlayArea().ToStringsForClient();
                gameClientModel.EnemyPlayArea = gameStateModel.Player1.GetPlayArea().ToStringsForClientEnemyPlayArea();
            }

            return gameClientModel;
        }
    }
}
