using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    public interface ISessionRepository
    {
        void AddNewPlayer(string name);

        void AddNewSession(NewSessionDto newSessionDto);

        void AddToStartsSessions(JoinToSessionDto newSessionDto);

        List<NewSessionDto> GetAllFreeSessions();

        NewSessionDto GetFreeSession(string sessionName);
    }
}