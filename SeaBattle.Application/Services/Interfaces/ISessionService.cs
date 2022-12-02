using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewSession(NewSessionClientModel newSessionClient);

        void JoinToSession(JoinToSessionClientModel joinSessionClient);

        List<NewSessionModel> GetAllNewSessions();
    }
}