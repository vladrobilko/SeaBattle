using SeaBattle.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Repository.Converters
{
    public static class GameStateModelConverter
    {
        public static GameStateDtoModel ConvertToGameStateDtoModel(this GameStateModel gameState, string nameSession)
        {
            return new GameStateDtoModel(
                gameState.Player1,
                gameState.Player2,
                nameSession,
                gameState.NamePlayerTurn,
                gameState.IsGameOn,
                gameState.GameMessage
                );
        }
    }
}
