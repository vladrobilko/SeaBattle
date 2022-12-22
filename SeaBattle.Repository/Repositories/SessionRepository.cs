using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;
using System.Data;

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

        public void SaveNewSessionOrThrowException(string hostPlayerName, string sessionName)
        {
            if (IsSessionExists(sessionName))
                throw new DuplicateNameException();
            _newSessionsWaitSecondPlayer.Add(new SessionDtoModel() { HostPlayerName = hostPlayerName, SessionName = sessionName });
        }

        public List<NewSessionModel> GetAllFreeSessionsOrThrowException()
        {
            if (_newSessionsWaitSecondPlayer.Count == 0)
                throw new DirectoryNotFoundException();
            return _newSessionsWaitSecondPlayer.ConvertToListSessionModel();
        }

        public void SaveStartsSessionsOrThrowException(string joinSessionName, string nameSession)
        {
            var session = _newSessionsWaitSecondPlayer.
                SingleOrDefault(p => p.SessionName == nameSession) ??
                throw new DirectoryNotFoundException();
            session.JoinPlayerName = joinSessionName;
            _waitingSessionsToStartGame.Add(session);
            _newSessionsWaitSecondPlayer.Remove(session);
        }

        public bool IsSessionReadyToStartGame(string nameSession)
        {
            return _waitingSessionsToStartGame.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }

        public bool IsSessionExists(string nameSession)
        {
            return _newSessionsWaitSecondPlayer.SingleOrDefault(p => p.SessionName == nameSession) != null ||
                _waitingSessionsToStartGame.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }

        public SessionModel GetFreeSessionByName(string nameSession)
        {
            var newSession = _newSessionsWaitSecondPlayer.
                SingleOrDefault(p => p.SessionName == nameSession);
            if (newSession == null)
                throw new DirectoryNotFoundException();
            return newSession.ConvertToSessionModel();
        }

        public SessionModel GetStartSessionByName(string nameSession)
        {
            var session = _waitingSessionsToStartGame.
                SingleOrDefault(p => p.SessionName == nameSession);
            if (session == null)
                throw new DirectoryNotFoundException();
            return session.ConvertToSessionModel();
        }
    }
}
