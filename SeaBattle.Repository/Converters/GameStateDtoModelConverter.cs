using SeaBattle.Repository.Models;

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
