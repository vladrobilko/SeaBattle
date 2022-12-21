using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Application.Services.Interfaces
{
    public interface ISeaBattleGameService
    {
        void GetPlayArea(InfoPlayerClientModel infoPlayerClientModel);

        //void ReadyToStartGame(); - тут будет старт игры если 2 игрока готовы

        //void GetGameModel();

        //void Shoot();
    }
}