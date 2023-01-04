using SeaBattle.Repository.Models;

namespace SeaBattle.Repository.Converters
{
    public static class GameStateDtoModelConverter
    {
        public static GameState ConvertToGameStateModel(this GameStateDtoModel gameStateDtoModel)
        {
            return new GameState(
                gameStateDtoModel.Player1,
                gameStateDtoModel.Player2,
                gameStateDtoModel.NamePlayerTurn,
                gameStateDtoModel.IsGameOn,
                gameStateDtoModel.GameMessage);
        }
    }
}
