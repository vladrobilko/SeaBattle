using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Converters;
using SeaBattle.Repository.Models;
using System.Data;

namespace SeaBattle.Repository.Repositories
{
    /*public class SessionRepository : ISessionRepository
    {
        private readonly List<HostSessionDtoModel> _hostSessionDtoModels;

        private readonly List<StartSessionDtoModel> _startSessionDtoModels;

        public SessionRepository()
        {
            _hostSessionDtoModels = new List<HostSessionDtoModel>();
            _startSessionDtoModels = new List<StartSessionDtoModel>();
        }

        public void SaveNewSession(HostSessionModel hostSessionModel)
        {
            if (IsSessionExists(hostSessionModel.NameSession))
                throw new DuplicateNameException();

            _hostSessionDtoModels.Add(hostSessionModel.ConvertToHostSessionDtoModel());
        }

        public List<HostSessionModel> GetAllHostSessions()
        {
            if (_hostSessionDtoModels.Count == 0)
                throw new DirectoryNotFoundException();

            return _hostSessionDtoModels.ConvertToListHostSessionModel();
        }

        public void SaveStartsSessions(JoinSessionModel joinSessionModel)
        {
            var hostSession = _hostSessionDtoModels.
                SingleOrDefault(p => p.NameSession == joinSessionModel.NameSession)
                ?? throw new DirectoryNotFoundException();

            var startSession = new StartSessionDtoModel()
            {
                NameHostPlayer = hostSession.NameHostPlayer,
                NameJoinPlayer = joinSessionModel.NameJoinPlayer,
                NameSession = hostSession.NameSession
            };

            _startSessionDtoModels.Add(startSession);

            _hostSessionDtoModels.Remove(hostSession);
        }

        public bool IsSessionExists(string nameSession)
        {
            return _hostSessionDtoModels.SingleOrDefault(p => p.NameSession == nameSession) != null ||
                _startSessionDtoModels.SingleOrDefault(p => p.NameSession == nameSession) != null;
        }

        public StartSessionModel GetStartSessionByNameOrNull(string nameSession)
        {
            var startSession = _startSessionDtoModels.
                SingleOrDefault(p => p.NameSession == nameSession);

            if (startSession == null)
            {
                return null;
            }

            return startSession.ConvertToStartSessionModel();
        }
    }*/
}
