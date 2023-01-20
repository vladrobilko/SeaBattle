using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Converters;
using SeaBattle.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var hostSessions = _context
                .Players
                .Join(_context.Sessions,
                pl => pl.Id,
                ses => ses.IdPlayerHost,
                (pl, ses) => new HostSessionModel
                {
                    NameHostPlayer = pl.Name,
                    NameSession = ses.Name
                }).ToList();

            if (hostSessions.Count == 0)
            {
                throw new NotImplementedException();
            }

            return hostSessions;
        }

        public void SaveNewSession(HostSessionModel hostSessionModel)
        {
            var player = _context.Players.FirstOrDefault(p => p.Name == hostSessionModel.NameHostPlayer)
                ?? throw new NotImplementedException();

            var session = new Session()
            {
                IdPlayerHost = player.Id,
                Name = hostSessionModel.NameSession
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public StartSessionModel GetStartSessionByNameOrNull(string nameSession)
        {
            var session = _context
                .Sessions
                .FirstOrDefault(p => p.Name == nameSession);

            if (session == null || session.IdPlayerJoin == null)
            {
                return null;
            }

            var playerHost = _context
                .Players
                .FirstOrDefault(p => p.Id == session.IdPlayerHost);

            var playerJoin = _context
                .Players
                .FirstOrDefault(p => p.Id == session.IdPlayerHost);

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
            var session = _context.Sessions.FirstOrDefault(p => p.Name == joinSessionModel.NameSession);

            if (session == null || session.IdPlayerJoin != null || session.StartSession != null)
            {
                throw new NotImplementedException();
            }

            session.StartSession = DateTime.UtcNow;
            session.IdPlayerJoin = _context.Players.FirstOrDefault(p => p.Name == joinSessionModel.NameJoinPlayer).Id;

            _context.Sessions.Update(session);
            _context.SaveChanges();
        }
    }
}
