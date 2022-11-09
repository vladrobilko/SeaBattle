using SeaBattle;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class SeaBattleGameSessionService : ISeaBattleGameSessionService
    {
        List<ISeaBattleGameSession> _session;

        public SeaBattleGameSessionService()
        {
            _session = new List<ISeaBattleGameSession>();
        }

        public void CreateSession(string idPlayer, string nameGame)
        {
            var playerClient = PlayerClientService.GetByIdOrName(id: idPlayer);
            var seaBattleGameSession = new SeaBattleGameSession();
            seaBattleGameSession.PlayerHost = playerClient;
            seaBattleGameSession.Name = nameGame;
            _session.Add(seaBattleGameSession);
        }

        public bool AddPlayerInSession(string idPlayer, string idSession)
        {
            var playerClient = PlayerClientService.GetByIdOrName(id: idPlayer);
            var seaBattleGameSession = GetSession(idSession);
            if (seaBattleGameSession != null && seaBattleGameSession.PlayerHost != null && seaBattleGameSession.IsStarted == false)
            {
                seaBattleGameSession.PlayerJoin = playerClient;
                seaBattleGameSession.IsStarted = true;
                return true;
            }
            return false;
        }

        public List<ISeaBattleGameSession> GetAllSessions()
        {
            return _session;
        }

        public ISeaBattleGameSession GetSession(string idSession)
        {
            return _session.SingleOrDefault(p => p.ID == idSession);
        }        
    }
}
