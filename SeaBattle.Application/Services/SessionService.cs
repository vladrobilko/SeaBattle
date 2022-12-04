using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository newSessionDtoRepository)
        {
            _sessionRepository = newSessionDtoRepository;
        }

        public void CreateNewSession(NewSessionClientModel newSessionClient)
        {
            _sessionRepository.AddNewSessionOrThrowExeption(newSessionClient.HostPlayerName, newSessionClient.SessionName);
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _sessionRepository.
                GetAllFreeSessions();
        }

        public void JoinToSession(JoinToSessionClientModel joinSessionClient)
        {
            _sessionRepository.AddToStartsSessionsOrThrowExeption(joinSessionClient.JoinPlayerName, joinSessionClient.SessionName);
        }
    }
}
