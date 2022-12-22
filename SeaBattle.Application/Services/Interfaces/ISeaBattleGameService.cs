using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Application.Services.Interfaces
{
    public interface ISeaBattleGameService
    {
        GameAreaClientModel GetPlayArea(InfoPlayerClientModel infoPlayerClientModel);

        void ReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel);

        GameClientModel GetGameModel(string nameSession, string nameClient);

        //void Shoot();
    }
}