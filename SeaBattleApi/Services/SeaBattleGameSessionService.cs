using SeaBattle;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class SeaBattleGameSessionService : ISeaBattleGameSessionService
    {
        List<SeaBattleGameSession> _session;

        public SeaBattleGameSessionService()
        {
            _session = new List<SeaBattleGameSession>();
        }

        public void CreateSession(SeaBattleGameSession seaBattleGameSession)
        {
            _session.Add(seaBattleGameSession);
        }

        public bool AddPlayerInSession(string idPlayer)
        {
            var playerClient = PlayerClientService.GetByIdOrName(id: idPlayer);
            if (playerClient != null)
            {
                var session = _session.FirstOrDefault(p => p.IsStarted == false);
                if (session !=null)
                {
                    session.PlayerJoin = playerClient;
                    session.IsStarted = true;
                    return true;
                }
            }
            return false;
        }

        public List<SeaBattleGameSession> GetAllSessions()
        {
            return _session;
        }

        public SeaBattleGameSession GetSession(string idSession)
        {
            return _session.SingleOrDefault(p => p.ID == idSession);
        }        

        private ISeaBattleGameSession SearchFreeSession()
        {
            return _session.FirstOrDefault(p => p.IsStarted == false);
        }
    }
}
