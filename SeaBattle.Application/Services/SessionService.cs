using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        private readonly IPlayerRepository _playerRepository;

        public SessionService(ISessionRepository newSessionDtoRepository, IPlayerRepository playerRepository)
        {
            _sessionRepository = newSessionDtoRepository;
            _playerRepository = playerRepository;
        }

        public void CreateNewSession(HostSessionClientModel newSessionClient)
        {
            if (!_playerRepository.IsPlayerRegistered(newSessionClient.HostPlayerName))
                throw new Exception("The player is not registered");
            _sessionRepository.AddNewSessionOrThrowException(newSessionClient.HostPlayerName, newSessionClient.SessionName);
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _sessionRepository.
                GetAllFreeSessionsOrThrowException();
        }

        public void JoinToSession(JoinSessionClientModel joinSessionClient)
        {
            if (!_playerRepository.IsPlayerRegistered(joinSessionClient.JoinPlayerName))
                throw new Exception("The player is not registered");
            _sessionRepository.
                AddToStartsSessionsOrThrowException
                (joinSessionClient.JoinPlayerName, joinSessionClient.SessionName);
        }
    }
}
