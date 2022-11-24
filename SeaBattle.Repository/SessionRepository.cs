
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly List<NewSessionDtoModel> _newsessions;

        private readonly List<JoinToSessionDtoModel> _startingsessions;

        private readonly List<PlayerDtoModel> _players;

        public SessionRepository()
        {
            _newsessions = new List<NewSessionDtoModel>();
            _players = new List<PlayerDtoModel>();
            _startingsessions = new List<JoinToSessionDtoModel>();
        }

        public void AddNewPlayer(string name)
        {
            var player = new PlayerDtoModel() { Name = name };
            _players.Add(player);
        }

        public void AddNewSession(NewSessionDtoModel newSessionDto)
        {
            _newsessions.Add(newSessionDto);
        }

        public List<NewSessionDtoModel> GetAllFreeSessions()
        {
            return _newsessions;
        }

        public void AddToStartsSessions(JoinToSessionDtoModel joinToSessionDto)
        {
            _startingsessions.Add(joinToSessionDto);
        }

        public NewSessionDtoModel GetFreeSession(string sessionName)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == sessionName);
        }

        public PlayerDtoModel GetPlayer(string playerName)
        {
            return _players.SingleOrDefault(p => p.Name == playerName);
        }
    }
}
