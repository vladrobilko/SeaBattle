using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    public class SessionRepository : ISessionRepository
    {
        private readonly List<NewSessionDto> _newsessions;

        private readonly List<JoinToSessionDto> _startingsessions;

        private readonly List<PlayerDto> _players;

        public SessionRepository()
        {
            _newsessions = new List<NewSessionDto>();
            _players = new List<PlayerDto>();
            _startingsessions = new List<JoinToSessionDto>();
        }

        public void AddNewPlayer(string name)
        {
            var player = new PlayerDto() { Name = name };
            _players.Add(player);
        }

        public void AddNewSession(NewSessionDto newSessionDto)
        {
            _newsessions.Add(newSessionDto);
        }

        public List<NewSessionDto> GetAllFreeSessions()
        {
            return _newsessions;
        }

        public void AddToStartsSessions(JoinToSessionDto joinToSessionDto)
        {
            _startingsessions.Add(joinToSessionDto);
        }

        public NewSessionDto GetFreeSession(string sessionName)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == sessionName);
        }
    }
}
