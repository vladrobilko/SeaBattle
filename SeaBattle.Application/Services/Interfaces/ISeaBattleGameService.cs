using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Application.Services.Interfaces
{
    public interface ISeaBattleGameService
    {
        GameAreaClientModel GetPlayArea(InfoPlayerClientModel infoPlayerClientModel);

        void ReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel);

        GameClientStateModel GetGameModel(InfoPlayerClientModel infoPlayerClientModel);

        void Shoot(ShootPlayerClientModel shootPlayerClientModel);
    }
}