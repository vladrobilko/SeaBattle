using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void CreateSession(HostSessionModel hostSessionModel);

        void UpdateStartSession(JoinSessionModel joinSessionModel);

        StartSessionModel ReadStartSessionByName(string nameSession);

        List<HostSessionModel> ReadAllHostSessions();
    }
}