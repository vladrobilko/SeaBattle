using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName);

        void AddToStartsSessionsOrThrowExeption(string joinPlayerName, string sessionName);

        SessionModel GetSessionModel(string nameSession);

        List<NewSessionModel> GetAllFreeSessions();

        bool IsSessionReadyToStartGame(string sessionName);
    }
}