using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;

namespace SeaBattle.Repository.Converters
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
            if (gameStateModel.Player1.NamePlayer == nameClient)
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
