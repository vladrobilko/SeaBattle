using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void SaveNewSessionOrThrowException(string hostPlayerName, string sessionName);

        void SaveStartsSessionsOrThrowException(string joinPlayerName, string sessionName);

        SessionModel GetFreeSessionByName(string nameSession);

        SessionModel GetStartSessionByName(string nameSession);

        List<NewSessionModel> GetAllFreeSessionsOrThrowException();

        bool IsSessionReadyToStartGame(string sessionName);

        bool IsSessionExists(string nameSession);
    }
}