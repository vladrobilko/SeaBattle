using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Repository.Services;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _db;

        public SessionService(ISessionRepository newSessionDtoRepository)
        {
            _db = newSessionDtoRepository;
        }

        public void CreateNewSession(NewSessionClientModel newSessionClient)
        {
            _db.AddNewSessionOrThrowExeption(newSessionClient.HostPlayerName, newSessionClient.SessionName);
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _db.
                GetAllFreeSessions().
                ConvertToListSessionModel();
        }

        public void JoinToSession(JoinToSessionClientModel joinSessionClient)
        {
            _db.AddToStartsSessionsOrThrowExeption(joinSessionClient.JoinPlayerName, joinSessionClient.SessionName);
        }
    }
}
