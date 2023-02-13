using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void CreateOrUpdatePlayerStateModel(IPlayer playerModel);

        PlayerSeaBattleStateModel ReadConfirmedPlayerStateModelByName(string? name);

        void UpdateGameStateModel(GameState gameStateModel, string NameSession);

        GameState ReadGameStateModelByNameSession(string nameSession);

        void UpdatePlayareaToReadyForGame(string? namePlayer);

        void CreateOrUpdateValidShoot(ShootModel shootModel);

        ShootModel ReadLastShootModelByName(string? namePlayer);

        void EndGameIfPlayerNotShooted(string nameSession);
    }   
}