using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class SeaBattleGameModelConverter
    {
        public static GameClientModel ConvertToGameClientModel(this SeaBattleGameModel seaBattleGameModel, string nameClient)
        {
            var gameClientModel = new GameClientModel();
            if (seaBattleGameModel.Player1.Name == nameClient)
            {
                gameClientModel.ClientPlayArea = seaBattleGameModel.Player1.GetPlayArea().ConvertToArrayStringForClient();
                gameClientModel.EnemyPlayArea = seaBattleGameModel.Player2.GetPlayArea().ConvertToArrayStringForClientEnemyPlayArea();
                //gameClientModel.IsPlayerTurnToShoot = true;
            }
            else
            {
                gameClientModel.ClientPlayArea = seaBattleGameModel.Player2.GetPlayArea().ConvertToArrayStringForClient();
                gameClientModel.EnemyPlayArea = seaBattleGameModel.Player1.GetPlayArea().ConvertToArrayStringForClientEnemyPlayArea();
            }

            gameClientModel.IsGameOn = true;
            //gameClientModel.Message = seaBattleGameModel.message
            return gameClientModel;
        }
    }
}
