using SeaBattleApi.Models;

namespace SeaBattleApi.Services.Intefaces
{
    public interface ISeaBattleGameSessionService
    {
        void CreateSession(SeaBattleGameSession seaBattleGameSession);
        bool AddPlayerInSession(string idPlayer);
        SeaBattleGameSession GetSession(string idSession);
        List<SeaBattleGameSession> GetAllSessions();
    }
}
