using SeaBattle.Application.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void ResaveLastPlayerStateModel(PlayerSeaBattleStateModel playerModel);

        void SaveConfirmedPlayerStateModel(string name);

        PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByName(string name);

        void ResaveGameStateModel(GameStateModel gameStateDtoModel);

        GameStateModel GetGameStateModelByNameSession(string nameSession);

    }
}