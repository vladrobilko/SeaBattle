using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly SeabattleContext _context;

        public SessionRepository(SeabattleContext context)
        {
            _context = context;
        }

        public List<HostSessionModel> GetAllHostSessions()
        {
            var hostSessions = _context.Players.Join(_context.Sessions,
                pl => pl.Id, ses => ses.IdPlayerHost,
                (pl, ses) => new
                {
                    NameHostPlayer = pl.Name,
                    NameSession = ses.Name,
                    TimeStart = ses.StartSession
                }).Where(t => t.TimeStart == null)
                .Select(s => new HostSessionModel()
                {
                    NameHostPlayer = s.NameHostPlayer,
                    NameSession = s.NameSession
                }).ToList();

            if (hostSessions.Count == 0)
            {
                throw new NotImplementedException();
            }

            return hostSessions;
        }

        public StartSessionModel GetStartSessionByNameOrNull(string nameSession)
        {
            var session = GetSessionByNameOrNull(nameSession);

            if (session == null || session.IdPlayerJoin == null)
            {
                return null;
            }

            var playerHost = GetPlayerByIdOrNull(session.IdPlayerHost);
            var playerJoin = GetPlayerByIdOrNull(session.IdPlayerHost);

            var startSessionModel = new StartSessionModel()
            {
                NameHostPlayer = playerHost.Name,
                NameJoinPlayer = playerJoin.Name,
                NameSession = nameSession
            };

            return startSessionModel;
        }
        public void SaveStartsSessions(JoinSessionModel joinSessionModel)
        {
            var session = GetSessionByNameOrNull(joinSessionModel.NameSession);

            if (session == null || session.IdPlayerJoin != null || session.StartSession != null)
            {
                throw new NotImplementedException();
            }

            session.StartSession = DateTime.UtcNow;
            session.IdPlayerJoin = GetPlayerByName(joinSessionModel.NameJoinPlayer).Id;

            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public void SaveNewSession(HostSessionModel hostSessionModel)
        {
            var player = GetPlayerByName(hostSessionModel.NameHostPlayer);

            var session = new SessionDto()
            {
                IdPlayerHost = player.Id,
                Name = hostSessionModel.NameSession
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        private PlayerDto GetPlayerByName(string namePlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Name == namePlayer)
                ?? throw new NotImplementedException();
        }

        private PlayerDto GetPlayerByIdOrNull(long idPlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Id == idPlayer);
        }

        private SessionDto GetSessionByNameOrNull(string nameSession)
        {
            return _context.Sessions.FirstOrDefault(p => p.Name == nameSession);
        }
    }
}
