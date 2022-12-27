using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void SaveNewSessionOrThrowException(string hostPlayerName, string sessionName);

        void SaveStartsSessionsOrThrowException(string joinPlayerName, string sessionName);

        SessionModel GetStartSessionByName(string nameSession);

        List<HostSessionModel> GetAllFreeSessionsOrThrowException();

        bool IsSessionExists(string nameSession);
    }
}