using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Interfaces;
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
            _sessionRepository
                .CreateSession(newSessionClient.ToHostSessionModel());

            Task.Run(() => _sessionRepository.EndSessionIfNoJoinPlayer(newSessionClient.SessionName));

            Task.Run(() => _sessionRepository.EndSessionIfPlayerNotConfirmedPlayArea(newSessionClient.HostPlayerName));
        }

        public List<HostSessionClientModel> GetAllHostSessions()
        {
            return _sessionRepository
                .ReadAllHostSessions()
                .ToHostSessionClientModels();
        }

        public void JoinToSession(JoinSessionClientModel joinSessionClient)
        {
            _sessionRepository
                .UpdateStartSession
                (joinSessionClient.ToJoinSessionModel());

            Task.Run(() => _sessionRepository.EndSessionIfPlayerNotConfirmedPlayArea(joinSessionClient.NameJoinPlayer));
        }
    }
}
