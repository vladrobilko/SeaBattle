using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewPlayer(string name);

        void CreateNewSession(NewSessionClientModel newSessionClient);

        void JoinToSession(JoinToSessionClientModel joinSessionClient);

        List<NewSessionModel> GetAllNewSessions();
    }
}