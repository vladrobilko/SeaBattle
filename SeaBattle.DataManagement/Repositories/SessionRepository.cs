using Microsoft.EntityFrameworkCore;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Converters;
using SeaBattle.DataManagement.Models;
using System.Numerics;

namespace SeaBattle.DataManagement.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly SeabattleContext _context;

        public SessionRepository(SeabattleContext context)
        {
            _context = context;
        }

        public List<HostSessionModel> ReadAllHostSessions()
        {
            var list = _context.Sessions.Include(s => s.IdPlayerHostNavigation)
            .Where(s => s.StartSession == null && s.EndSession == null && s.IdPlayerJoin == null)
            .Select(p => new HostSessionModel()
            {
                NameHostPlayer = p.IdPlayerHostNavigation.Name,
                NameSession = p.Name
            }).ToList();

            return list;
        }

        public StartSessionModel ReadStartSessionByName(string nameSession)
        {
            var session = ReadSessionByName(nameSession);

            if (session == null || session.IdPlayerJoin == null)
            {
                return null;
            }

            var playerHost = ReadPlayerById(session.IdPlayerHost);
            var playerJoin = ReadPlayerById(session.IdPlayerHost);

            var startSessionModel = new StartSessionModel()
            {
                NameHostPlayer = playerHost.Name,
                NameJoinPlayer = playerJoin.Name,
                NameSession = nameSession
            };

            return startSessionModel;
        }

        public void UpdateStartSession(JoinSessionModel joinSessionModel)
        {
            var session = ReadSessionByName(joinSessionModel.NameSession);

            if (session == null || session.IdPlayerJoin != null || session.StartSession != null)
            {
                throw new NotImplementedException();
            }

            session.StartSession = DateTime.UtcNow;
            session.IdPlayerJoin = ReadPlayerByName(joinSessionModel.NameJoinPlayer).Id;

            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public void CreateSession(HostSessionModel hostSessionModel)
        {
            var player = ReadPlayerByName(hostSessionModel.NameHostPlayer);

            var session = new SessionDto()
            {
                IdPlayerHost = player.Id,
                Name = hostSessionModel.NameSession
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public void EndSessionIfNoJoinPlayer(string nameSession)
        {
            Thread.Sleep(new TimeSpan(0, 3, 0));
            var context = new SeabattleContext();
            var session = context.Sessions.First(p => p.Name == nameSession);
            if (session.IdPlayerJoin == null)
            {
                session.EndSession = DateTime.UtcNow;
                context.Sessions.Update(session);
                context.SaveChanges();
            }
        }

        public void EndSessionIfPlayerNotConfirmedPlayarea(string namePlayer)
        {
            Thread.Sleep(new TimeSpan(0, 3, 0));
            var context = new SeabattleContext();
            var idPlayer = context.Players.First(p => p.Name == namePlayer).Id;
            var playArea = context.Playareas.FirstOrDefault(p => p.IdPlayer == idPlayer);

            if (playArea.ConfirmedPlayarea == null)
            {
                var session = context.Sessions.First(p => p.IdPlayerHost == idPlayer || p.IdPlayerJoin == idPlayer);
                session.EndSession = DateTime.UtcNow;

                context.Sessions.Update(session);
                context.SaveChanges();
            }
        }

        private PlayerDto ReadPlayerByName(string namePlayer)
        {
            return _context.Players.Single(p => p.Name == namePlayer);
        }

        private PlayerDto ReadPlayerById(long idPlayer)
        {
            return _context.Players.Single(p => p.Id == idPlayer);
        }

        private SessionDto ReadSessionByName(string nameSession)
        {
            return _context.Sessions.SingleOrDefault(p => p.Name == nameSession);
        }
    }
}
