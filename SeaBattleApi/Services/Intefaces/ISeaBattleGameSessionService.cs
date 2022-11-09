using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Services.Intefaces
{
    public interface ISeaBattleGameSessionService
    {
        void CreateSession(string idPlayer, string nameGame);
        bool AddPlayerInSession(string idPlayer, string idSession);
        ISeaBattleGameSession GetSession(string idSession);
        List<ISeaBattleGameSession> GetAllSessions();
    }
}
