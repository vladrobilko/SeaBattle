
using SeaBattle.Repository.Models;
using SeaBattle.Repository.Services;
using System.Text;
using System.Xml.Linq;

namespace SeaBattle.Repository
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

        public List<SessionDtoModel> GetAllFreeSessions()
        {
            return _newSessionsWaitSecondPlayer;
        }

        public void AddToStartsSessionsOrThrowExeption(string joinSessionName, string nameSession)
        {
            var session = _newSessionsWaitSecondPlayer.SingleOrDefault(p => p.SessionName == nameSession) ?? throw new Exception("Session not found.");
            session.JoinPlayerName = joinSessionName;
            _newSessionsWaitSecondPlayer.Remove(session);
            _waitingSessionsToStartGame.Add(session);
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
    }//Наврное надо где то удалять сессию из ожидания когда игра началась
}
