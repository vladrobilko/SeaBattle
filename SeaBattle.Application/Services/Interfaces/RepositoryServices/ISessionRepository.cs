using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void SaveNewSessionOrThrowException(HostSessionModel hostSessionModel);

        void SaveStartsSessionsOrThrowException(JoinSessionModel joinSessionModel);

        StartSessionModel GetStartSessionByNameOrNull(string nameSession);

        List<HostSessionModel> GetAllFreeSessionsOrThrowException();

        bool IsSessionExists(string nameSession);
    }
}