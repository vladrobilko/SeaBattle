using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private string NameGame = "Sea battle";
        PlayerClient Player { get; set; }

        public string GetGameName()
        {
            return NameGame;
        }
    }
}
