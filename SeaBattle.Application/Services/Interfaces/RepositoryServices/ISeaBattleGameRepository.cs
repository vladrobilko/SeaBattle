using SeaBattle.Application.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel);

        void SaveConfirmedPlayerStateModel(string name);

        PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name);

        void ResaveGameStateModel(GameStateModel gameStateModel);

        GameStateModel GetGameStateModelOrThrowExceptionByNameSession(string nameSession);

        void ResaveValidShoot(ShootModel shootModel);

        ShootModel GetLastShootModelOrNullByNameSession(string nameSession);

        void ChangeGameStateModel(string nameSession, IPlayer? playerToChange = null,
            string? namePlayerTurn = null, bool IsGameOn = true, string? gameMessage = null);
    }
}