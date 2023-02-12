using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface ISessionRepository
    {
        void CreateSession(HostSessionModel hostSessionModel);

        void UpdateStartSession(JoinSessionModel joinSessionModel);

        StartSessionModel ReadStartSessionByName(string nameSession);

        List<HostSessionModel> ReadAllHostSessions();

        void EndSessionIfNoJoinPlayer(string nameSession);

        void EndSessionIfPlayerNotConfirmedPlayarea(string namePlayer);
    }
}