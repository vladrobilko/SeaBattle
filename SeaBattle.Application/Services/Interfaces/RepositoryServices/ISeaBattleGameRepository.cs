using SeaBattle.Application.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void SaveOrResavePlayerStateModel(IPlayer playerModel);

        PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByNameOrNull(string name);

        void ResaveGameStateModel(GameState gameStateModel, string NameSession);

        GameState GetGameStateModelByNameSession(string nameSession);

        void ReadyToStartGame(string namePlayer);

        void ResaveValidShoot(ShootModel shootModel);

        ShootModel GetLastShootModelOrNullByName(string namePlayer);
    }   
}