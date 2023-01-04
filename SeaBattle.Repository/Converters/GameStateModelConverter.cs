using SeaBattle.Repository.Models;

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
                gameState.GameMessage);
        }
    }
}
