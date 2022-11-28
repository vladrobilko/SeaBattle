
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

        public void AddNewSession(SessionDtoModel newSessionDto)
        {
            _newsessions.Add(newSessionDto);
        }

        public List<SessionDtoModel> GetAllFreeSessions()
        {
            return _newsessions;
        }

        public void AddToStartsSessions(SessionDtoModel joinToSessionDto)
        {
            _startingsessions.Add(joinToSessionDto);
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
