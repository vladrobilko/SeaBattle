using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Repository;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        ISeaBattleRepository _db;

        public SessionService(ISeaBattleRepository newSessionDtoRepository)
        {
            _db = newSessionDtoRepository;
        }
        public void CreateNewPlayer(string name)
        {
            _db.AddNewPlayer(name);
        }

        public void CreateNewSession(NewSessionClientModel newSessionClient)
        {
            if (_db.IsSessionExists(newSessionClient.SessionName))
            {
                throw new Exception("The session has already been created");
            }
            _db.AddNewSession(newSessionClient.HostPlayerName, newSessionClient.SessionName);
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
