
using SeaBattle.Repository.Models;
using System.Xml.Linq;

namespace SeaBattle.Repository
{
    public class SeaBattleRepository : ISeaBattleRepository
    {
        private readonly List<SessionDtoModel> _newsessions;

        private readonly List<SessionDtoModel> _startingsessions;

        private readonly List<PlayerDtoModel> _registeredPlayers;

        public SeaBattleRepository()
        {
            _newsessions = new List<SessionDtoModel>();
            _registeredPlayers = new List<PlayerDtoModel>();
            _startingsessions = new List<SessionDtoModel>();
        }

        public void AddNewPlayerOrThrowExeption(string name)
        {
            if (IsPlayerRegistered(name))
                throw new Exception("The name is occupied.");
            var player = new PlayerDtoModel() { Name = name };
            _registeredPlayers.Add(player);
        }

        public void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName)
        {
            if (IsSessionExists(sessionName))
                throw new Exception("The session has already been created");
            else if (!IsPlayerRegistered(hostPlayerName))
                throw new Exception("The player is not registered");
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
            _startingsessions.Add(session);
        }

        private bool IsSessionExists(string nameSession)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == nameSession) != null ||
                _startingsessions.SingleOrDefault(p => p.SessionName == nameSession) != null;
        }

        private bool IsPlayerRegistered(string name)
        {
            return _registeredPlayers.SingleOrDefault(p => p.Name == name) != null;
        }
    }
}
