using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewSession(HostSessionClientModel newSessionClient);

        void JoinToSession(JoinSessionClientModel joinSessionClient);

        List<HostSessionClientModel> GetAllHostSessions();
    }
}