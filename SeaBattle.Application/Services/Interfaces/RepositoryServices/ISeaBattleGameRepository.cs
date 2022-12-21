using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISeaBattleGameRepository
    {
        void SaveLastPlayerModel(PlayerModel playerModel);

        void SaveConfirmedPlayerModel(string name);

        //void SaveGameModel();

        //void SaveGame();

    }
}