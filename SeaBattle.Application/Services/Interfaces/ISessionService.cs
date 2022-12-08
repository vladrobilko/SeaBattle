using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewSession(HostSessionClientModel newSessionClient);

        void JoinToSession(JoinSessionClientModel joinSessionClient);

        List<NewSessionModel> GetAllNewSessions();
    }
}