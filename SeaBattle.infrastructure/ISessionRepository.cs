using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    public interface ISessionRepository
    {
        void AddNewPlayer(string name);

        void AddNewSession(NewSessionDtoModel newSessionDto);

        void AddToStartsSessions(JoinToSessionDtoModel newSessionDto);

        List<NewSessionDtoModel> GetAllFreeSessions();

        NewSessionDtoModel GetFreeSession(string sessionName);

        PlayerDtoModel GetPlayer(string playerName);
    }
}