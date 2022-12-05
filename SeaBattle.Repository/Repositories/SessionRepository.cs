using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly List<SessionDtoModel> _newSessionsWaitSecondPlayer;

        private readonly List<SessionDtoModel> _waitingSessionsToStartGame;

        public SessionRepository()
        {
            _newSessionsWaitSecondPlayer = new List<SessionDtoModel>();
            _waitingSessionsToStartGame = new List<SessionDtoModel>();
        }

        public void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName)
        {
            if (IsSessionExists(sessionName))
                throw new Exception("The session has already been created");
            _newSessionsWaitSecondPlayer.Add(new SessionDtoModel() { HostPlayerName = hostPlayerName, SessionName = sessionName });
        }

        public List<NewSessionModel> GetAllFreeSessions()
        {
            return _newSessionsWaitSecondPlayer.ConvertToListSessionModel();
        }

        public void AddToStartsSessionsOrThrowExeption(string joinSessionName, string nameSession)
        {
            var session = _newSessionsWaitSecondPlayer.SingleOrDefault(p => p.SessionName == nameSession) ?? throw new Exception("Session not found.");
            session.JoinPlayerName = joinSessionName;
            _waitingSessionsToStartGame.Add(session);
            _newSessionsWaitSecondPlayer.Remove(session);
        }

        public bool IsSessionReadyToStartGame(string nameSession)
        {
            return _waitingSessionsToStartGame.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }

        private bool IsSessionExists(string nameSession)
        {
            return _newSessionsWaitSecondPlayer.SingleOrDefault(p => p.SessionName == nameSession) != null ||
                _waitingSessionsToStartGame.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }

        public SessionModel GetFreeSessionByName(string nameSession)
        {
            var newSession = _newSessionsWaitSecondPlayer.
                SingleOrDefault(p => p.SessionName == nameSession);
            if (newSession == null)
                throw new Exception("Session not found.");
            return newSession.ConvertToSessionModel();
        }

        public SessionModel GetStartSessionByName(string nameSession)
        {
            var session = _waitingSessionsToStartGame.
                SingleOrDefault(p => p.SessionName == nameSession);
            if (session == null)
                throw new Exception("Session not found.");
            return session.ConvertToSessionModel();
        }
    }
}
