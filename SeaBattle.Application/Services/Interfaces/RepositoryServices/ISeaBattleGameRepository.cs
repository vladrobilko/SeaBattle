using SeaBattle.Application.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void SaveLastPlayerModel(PlayerModel playerModel);

        void SaveConfirmedPlayerModel(string name);

        PlayerModel GetConfirmedPlayerModelByName(string name);

        //void SaveGame();

    }
}