using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void AddNewSessionOrThrowException(string hostPlayerName, string sessionName);

        void AddToStartsSessionsOrThrowException(string joinPlayerName, string sessionName);

        SessionModel GetFreeSessionByName(string nameSession);

        SessionModel GetStartSessionByName(string nameSession);

        List<NewSessionModel> GetAllFreeSessionsOrThrowException();

        bool IsSessionReadyToStartGame(string sessionName);

        bool IsSessionExists(string nameSession);
    }
}