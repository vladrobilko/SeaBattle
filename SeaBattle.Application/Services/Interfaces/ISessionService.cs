using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewPlayer(string name);

        void CreateNewSession(NewSessionClientModel newSessionClient);

        bool IsJoinToSession(JoinToSessionClientModel joinSessionClient);

        List<NewSessionModel> GetAllNewSessions();
    }
}