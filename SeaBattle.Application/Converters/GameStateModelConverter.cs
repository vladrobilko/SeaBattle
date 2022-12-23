using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class GameStateModelConverter
    {
        public static GameClientStateModel ConvertToGameClientModel(this GameStateModel gameStateModel, string nameClient)
        {
            var gameClientModel = new GameClientStateModel()
            {
                IsGameOn = gameStateModel.IsGameOn,
                NamePlayerTurn = nameClient,
                Message = gameStateModel.GameMessage
            };
            if (gameStateModel.Player1.Name == nameClient)
            {
                gameClientModel.ClientPlayArea = gameStateModel.Player1.GetPlayArea().ConvertToArrayStringForClient();
                gameClientModel.EnemyPlayArea = gameStateModel.Player2.GetPlayArea().ConvertToArrayStringForClientEnemyPlayArea();
            }
            else
            {
                gameClientModel.ClientPlayArea = gameStateModel.Player2.GetPlayArea().ConvertToArrayStringForClient();
                gameClientModel.EnemyPlayArea = gameStateModel.Player1.GetPlayArea().ConvertToArrayStringForClientEnemyPlayArea();
            }

            return gameClientModel;
        }
    }
}
