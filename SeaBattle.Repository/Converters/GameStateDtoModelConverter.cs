using SeaBattle.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Repository.Converters
{
    public static class GameStateDtoModelConverter
    {
        public static GameStateModel ConvertToGameStateModel(this GameStateDtoModel gameStateDtoModel)
        {
            return new GameStateModel(
                gameStateDtoModel.Player1,
                gameStateDtoModel.Player2,
                gameStateDtoModel.NamePlayerTurn,
                gameStateDtoModel.IsGameOn,
                gameStateDtoModel.GameMessage);
        }
    }
}
