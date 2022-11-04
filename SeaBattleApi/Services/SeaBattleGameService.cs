using SeaBattle;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private string NameGame = "Sea battle";

        public string GetName()
        {
            return NameGame;
        }

        public string Start(IPlayerClientService player1, IPlayerClientService player2)
        {
            throw new NotImplementedException();
        }
    }
}
