using SeaBattle;

namespace SeaBattleApi.Services.Intefaces
{
    public interface ISeaBattleGameService
    {
        string GetName();

        string Start(IPlayerClientService player1, IPlayerClientService player2);
    }
}
