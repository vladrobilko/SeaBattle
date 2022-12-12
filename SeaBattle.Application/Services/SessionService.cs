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

        public void CreateNewSession(HostSessionClientModel newSessionClient)
        {
            _sessionRepository.AddNewSessionOrThrowException(newSessionClient.HostPlayerName, newSessionClient.SessionName);
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _sessionRepository.
                GetAllFreeSessionsOrThrowException();
        }

        public void JoinToSession(JoinSessionClientModel joinSessionClient)
        {
            _sessionRepository.AddToStartsSessionsOrThrowException(joinSessionClient.JoinPlayerName, joinSessionClient.SessionName);
        }
    }
}
