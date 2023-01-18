using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void SaveNewSession(HostSessionModel hostSessionModel);

        void SaveStartsSessions(JoinSessionModel joinSessionModel);

        StartSessionModel GetStartSessionByNameOrNull(string nameSession);

        List<HostSessionModel> GetAllHostSessions();
    }
}