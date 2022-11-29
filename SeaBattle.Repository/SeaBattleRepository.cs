
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository
{
    public class SeaBattleRepository : ISeaBattleRepository
    {
        private readonly List<SessionDtoModel> _newsessions;

        private readonly List<SessionDtoModel> _startingsessions;

        private readonly List<PlayerDtoModel> _players;

        public SeaBattleRepository()
        {
            _newsessions = new List<SessionDtoModel>();
            _players = new List<PlayerDtoModel>();
            _startingsessions = new List<SessionDtoModel>();
        }

        public void AddNewPlayer(string name)
        {
            var player = new PlayerDtoModel() { Name = name };
            _players.Add(player);
        }

        public void AddNewSession(string hostPlayerName, string sessionName)
        {
            _newsessions.Add(new SessionDtoModel() { HostPlayerName = hostPlayerName, SessionName = sessionName });
        }

        public List<SessionDtoModel> GetAllFreeSessions()
        {
            return _newsessions;
        }

        public void AddToStartsSessionsOrThrowExeption(string joinSessionName, string nameSession)
        {
            var session = GetFreeSession(nameSession) ?? throw new Exception("Session not found.");
            if (session == null)
                throw new Exception("Session not found.");
            session.JoinPlayerName = joinSessionName;
            _startingsessions.Add(session);
        }

        public SessionDtoModel GetFreeSession(string sessionName)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == sessionName);
        }

        public PlayerDtoModel GetPlayer(string playerName)
        {
            return _players.SingleOrDefault(p => p.Name == playerName);
        }
    }
}
