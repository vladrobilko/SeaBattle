using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
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
            throw new NotImplementedException();
        }

        public StartSessionModel GetStartSessionByNameOrNull(string nameSession)
        {
            throw new NotImplementedException();
        }

        public bool IsSessionExists(string nameSession)
        {
            throw new NotImplementedException();
        }

        public void SaveNewSession(HostSessionModel hostSessionModel)
        {
            throw new NotImplementedException();
        }

        public void SaveStartsSessions(JoinSessionModel joinSessionModel)
        {
            throw new NotImplementedException();
        }
    }
}
