using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface ISessionService
    {
        void CreateNewPlayer(string name);

        void CreateNewSession(NewSessionClient newSessionClient);

        bool IsJoinToSession(JoinToSessionClient joinSessionClient);

        List<NewSessionModel> GetAllNewSessions();
    }
}