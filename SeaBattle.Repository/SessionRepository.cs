
using SeaBattle.Repository.Models;
using SeaBattle.Repository.Services;
using System.Xml.Linq;

namespace SeaBattle.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly List<SessionDtoModel> _newsessions;

        private readonly List<SessionDtoModel> _startingsessions;

        public SessionRepository()
        {
            _newsessions = new List<SessionDtoModel>();
            _startingsessions= new List<SessionDtoModel>();
        }


        public void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName)
        {
            if (IsSessionExists(sessionName))
                throw new Exception("The session has already been created");
            _newsessions.Add(new SessionDtoModel() { HostPlayerName = hostPlayerName, SessionName = sessionName });
        }

        public List<SessionDtoModel> GetAllFreeSessions()
        {
            return _newsessions;
        }

        public void AddToStartsSessionsOrThrowExeption(string joinSessionName, string nameSession)
        {
            var session = _newsessions.SingleOrDefault(p => p.SessionName == nameSession) ?? throw new Exception("Session not found.");
            session.JoinPlayerName = joinSessionName;
            _newsessions.Remove(session);
            _startingsessions.Add(session);
        }

        private bool IsSessionExists(string nameSession)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == nameSession) != null ||
                _startingsessions.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }
    }
}
