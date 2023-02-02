using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
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
            _sessionRepository
                .SaveNewSession(newSessionClient.ToHostSessionModel());
        }

        public List<HostSessionClientModel> GetAllHostSessions()
        {
            return _sessionRepository
                .GetAllHostSessions()
                .ToHostSessionClientModels();
        }

        public void JoinToSession(JoinSessionClientModel joinSessionClient)
        {
            _sessionRepository
                .SaveStartsSessions
                (joinSessionClient.ToJoinSessionModel());
        }
    }
}
